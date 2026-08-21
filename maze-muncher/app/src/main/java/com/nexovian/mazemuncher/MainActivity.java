package com.nexovian.mazemuncher;

import android.app.*;
import android.os.*;
import android.graphics.*;
import android.graphics.drawable.*;
import android.view.*;
import android.content.*;
import java.util.*;

public class MainActivity extends Activity {
    @Override public void onCreate(Bundle b) { super.onCreate(b); getWindow().setFlags(1024,1024); setContentView(new GameView(this)); }
}

class GameView extends View {
    static final int COLS=19, ROWS=23;
    final Paint p=new Paint(3); final Random rnd=new Random();
    int[][] map=new int[ROWS][COLS];
    float px,py; int dir=1,next=1,score=0,lives=3,level=1,pellets=0; boolean over=false;
    float sx,sy; long last;
    ArrayList<Enemy> enemies=new ArrayList<>();
    final String[] maze={
      "###################","#........#........#","#.###.##.#.##.###.#","#o###.##.#.##.###o#","#.................#","#.###.#.#####.#.###","#.....#...#...#...#","#####.### # ###.###","    #.#       #.#  ","#####.# ## ## #.###","     .  #   #  .   ","#####.# ##### #.###","    #.#       #.#  ","#####.# ##### #.###","#........#........#","#.###.##.#.##.###.#","#o..#.... ....#..o#","###.#.#.#####.#.###","#.....#...#...#...#","#.#######.#.#######","#.................#","#.................#","###################"};
    GameView(Context c){super(c);p.setTypeface(Typeface.create("sans",Typeface.BOLD));setBackgroundColor(Color.rgb(7,10,24));resetLevel();last=System.nanoTime();}
    void resetLevel(){pellets=0;for(int r=0;r<ROWS;r++)for(int c=0;c<COLS;c++){char ch=maze[r].charAt(c);map[r][c]=ch=='#'?1:(ch=='.'?2:(ch=='o'?3:0));if(map[r][c]>=2)pellets++;}px=9;py=16;dir=1;next=1;enemies.clear();enemies.add(new Enemy(9,10,Color.rgb(255,70,95)));enemies.add(new Enemy(8,10,Color.rgb(0,220,255)));enemies.add(new Enemy(10,10,Color.rgb(255,130,220)));enemies.add(new Enemy(9,12,Color.rgb(255,165,60)));}
    boolean wall(float x,float y){int c=Math.round(x),r=Math.round(y);return r<0||r>=ROWS||c<0||c>=COLS||map[r][c]==1;}
    void step(float dt){if(over)return;float speed=5.0f+level*.12f;int[] dx={0,1,0,-1},dy={-1,0,1,0};float cx=Math.round(px),cy=Math.round(py);if(Math.abs(px-cx)<.12&&Math.abs(py-cy)<.12){px=cx;py=cy;if(!wall(px+dx[next],py+dy[next]))dir=next;if(wall(px+dx[dir],py+dy[dir])){}else{px+=dx[dir]*speed*dt;py+=dy[dir]*speed*dt;}}else{px+=dx[dir]*speed*dt;py+=dy[dir]*speed*dt;}if(px<-.5)px=COLS-.5f;if(px>COLS-.5)px=-.5f;int c=Math.round(px),r=Math.round(py);if(r>=0&&r<ROWS&&c>=0&&c<COLS&&map[r][c]>=2){score+=map[r][c]==3?50:10;map[r][c]=0;pellets--;if(pellets<=0){level++;resetLevel();return;}}
      for(Enemy e:enemies){e.move(dt,map,rnd);float ddx=e.x-px,ddy=e.y-py;if(ddx*ddx+ddy*ddy<.45f){lives--;if(lives<=0)over=true;else{px=9;py=16;dir=1;next=1;for(int i=0;i<enemies.size();i++){enemies.get(i).x=8+i%3;enemies.get(i).y=10+i/3;}}break;}}
    }
    @Override protected void onDraw(Canvas c){super.onDraw(c);long now=System.nanoTime();float dt=Math.min(.033f,(now-last)/1e9f);last=now;step(dt);float w=getWidth(),h=getHeight();float top=90f;float cell=Math.min(w/COLS,(h-top-35)/ROWS);float ox=(w-cell*COLS)/2;
      p.setTextSize(34);p.setColor(Color.WHITE);c.drawText("MAZE MUNCHER",22,42,p);p.setTextSize(22);p.setColor(Color.rgb(130,245,255));c.drawText("SCORE  "+score,22,73,p);p.setColor(Color.rgb(255,210,65));c.drawText("LIVES  "+lives,w*.42f,73,p);p.setColor(Color.rgb(190,140,255));c.drawText("LV "+level,w*.78f,73,p);
      for(int r=0;r<ROWS;r++)for(int col=0;col<COLS;col++){float x=ox+col*cell,y=top+r*cell;if(map[r][col]==1){p.setStyle(Paint.Style.STROKE);p.setStrokeWidth(Math.max(2,cell*.10f));p.setColor(Color.rgb(80,70,255));c.drawRoundRect(x+2,y+2,x+cell-2,y+cell-2,cell*.2f,cell*.2f,p);p.setStyle(Paint.Style.FILL);}else if(map[r][col]>=2){p.setColor(map[r][col]==3?Color.rgb(255,120,210):Color.rgb(245,230,180));float rr=map[r][col]==3?cell*.16f:cell*.07f;c.drawCircle(x+cell/2,y+cell/2,rr,p);}}
      float x=ox+(px+.5f)*cell,y=top+(py+.5f)*cell;p.setColor(Color.rgb(80,255,145));c.drawCircle(x,y,cell*.38f,p);p.setColor(Color.rgb(7,10,24));float a=dir*(float)Math.PI/2;Path mouth=new Path();mouth.moveTo(x,y);mouth.lineTo(x+(float)Math.cos(a-.45)*cell*.46f,y+(float)Math.sin(a-.45)*cell*.46f);mouth.lineTo(x+(float)Math.cos(a+.45)*cell*.46f,y+(float)Math.sin(a+.45)*cell*.46f);mouth.close();c.drawPath(mouth,p);
      for(Enemy e:enemies)e.draw(c,p,ox,top,cell);if(over){p.setColor(0xCC070A18);c.drawRect(0,h*.35f,w,h*.65f,p);p.setTextAlign(Paint.Align.CENTER);p.setTextSize(46);p.setColor(Color.WHITE);c.drawText("GAME OVER",w/2,h*.47f,p);p.setTextSize(23);p.setColor(Color.rgb(130,245,255));c.drawText("TOQUE PARA RECOMEÇAR",w/2,h*.55f,p);p.setTextAlign(Paint.Align.LEFT);}invalidate();}
    @Override public boolean onTouchEvent(android.view.MotionEvent e){if(e.getAction()==0){sx=e.getX();sy=e.getY();if(over){score=0;lives=3;level=1;over=false;resetLevel();}return true;}if(e.getAction()==1){float dx=e.getX()-sx,dy=e.getY()-sy;if(Math.abs(dx)>Math.abs(dy))next=dx>0?1:3;else next=dy>0?2:0;return true;}return true;}
}
class Enemy {float x,y;int dir;int color;Enemy(float a,float b,int c){x=a;y=b;color=c;dir=0;}void move(float dt,int[][] m,Random r){int[] dx={0,1,0,-1},dy={-1,0,1,0};float cx=Math.round(x),cy=Math.round(y);if(Math.abs(x-cx)<.10&&Math.abs(y-cy)<.10){x=cx;y=cy;ArrayList<Integer> o=new ArrayList<>();for(int d=0;d<4;d++){int nx=(int)x+dx[d],ny=(int)y+dy[d];if(ny>=0&&ny<m.length&&nx>=0&&nx<m[0].length&&m[ny][nx]!=1&&d!=(dir+2)%4)o.add(d);}if(o.size()>0)dir=o.get(r.nextInt(o.size()));}x+=dx[dir]*3.5f*dt;y+=dy[dir]*3.5f*dt;if(x<-.5)x=m[0].length-.5f;if(x>m[0].length-.5)x=-.5f;}void draw(Canvas c,Paint p,float ox,float top,float cell){float cx=ox+(x+.5f)*cell,cy=top+(y+.5f)*cell;p.setColor(color);RectF rr=new RectF(cx-cell*.34f,cy-cell*.34f,cx+cell*.34f,cy+cell*.34f);c.drawRoundRect(rr,cell*.28f,cell*.28f,p);p.setColor(Color.WHITE);c.drawCircle(cx-cell*.13f,cy-cell*.08f,cell*.09f,p);c.drawCircle(cx+cell*.13f,cy-cell*.08f,cell*.09f,p);p.setColor(Color.rgb(20,35,80));c.drawCircle(cx-cell*.13f,cy-cell*.08f,cell*.04f,p);c.drawCircle(cx+cell*.13f,cy-cell*.08f,cell*.04f,p);}}
