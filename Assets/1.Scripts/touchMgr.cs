using UnityEngine;
using System.Collections;

public class touchPos
{
    
    Vector2 pos;




}



public class touchMgr : MonoBehaviour {

    


    public static touchMgr touch;

	public bool[] Begin_Touch;
	public bool[] Move_Touch;
	public bool[] Any_touch;
	public bool[] End_Touch;

	// 델리게이트   선언 
	delegate void listener( string type, int id, float x, float y, float dx, float dy );
	// 선언 한걸 타입으로  변수를 만든다. 
	event listener begin0, begin1, begin2, begin3, begin4;
	event listener move0, move1, move2, move3, move4;
	event listener end0, end1, end2, end3, end4;
	
	Vector2[] delta = new Vector2[5];

	public Vector2[] beginPos  = new Vector2[5];
	//public Vector2[] MovsPos  = new Vector2[5];
	//public Vector2[] AnyPos = new Vector2[5];
	public Vector2[] EndPos = new Vector2[5];

	//public Vector2[] Pos = new Vector2[5];
	public int count=0;
	//private Vector2[] EndPos;   = new Vector2[5];
	void Awake()
	{
       // touch = this;
        //// touch 가  없으면 만들고 있으면  파괴 
       if (touch == null)
       {
           DontDestroyOnLoad(gameObject);
           touch = this;

       }
       else if (touch != null)
       {

           Destroy(gameObject);
       }

        Begin_Touch =new bool[5];
		Move_Touch = new bool[5];
		Any_touch= new bool[5];
		End_Touch= new bool[5];


		for (int i =0; i<5; i++) {
			//Debug.Log("test"+i);
			Begin_Touch[i] = false;
			Move_Touch[i] = false;
			Any_touch[i] = false;
			End_Touch[i] = true;
		}
	}

    public int touch_fingerId = -1;
   void Update()
    {

         

            //count = Input.touchCount;

            count = Input.touches.Length;


        

            for (int i = 0; i < count; i++)
            {
                Touch touch = Input.GetTouch(i);
                int id = touch.fingerId;
                touch_fingerId = id;
                Vector2 pos = touch.position;

                if (touch.phase == TouchPhase.Began)
                {
                    delta[id] = touch.position;
                }
                float x, y, dx, dy;
                x = pos.x;
                y = pos.y;
                //print ("x:"+x+"y:"+y);

                if (touch.phase == TouchPhase.Began)
                {
                    dx = dy = 0;

                }
                else
                {
                    // 움직임 거리 계산 할때 
                    dx = pos.x - delta[id].x;
                    dy = pos.y - delta[id].y;

                }


                //상태에 따라 이벤트를 호출하자
                if (touch.phase == TouchPhase.Began)
                {

                    switch (id)
                    {
                        case 0: if (begin0 != null) begin0("begin", id, x, y, dx, dy); break;
                        case 1: if (begin1 != null) begin1("begin", id, x, y, dx, dy); break;
                        case 2: if (begin2 != null) begin2("begin", id, x, y, dx, dy); break;
                        case 3: if (begin3 != null) begin3("begin", id, x, y, dx, dy); break;
                        case 4: if (begin4 != null) begin4("begin", id, x, y, dx, dy); break;
                    }
                }
                //else if (touch.phase == TouchPhase.Moved)
                //{

                //    switch (id)
                //    {
                //        case 0: if (move0 != null) move0("move", id, x, y, dx, dy); break;
                //        case 1: if (move1 != null) move1("move", id, x, y, dx, dy); break;
                //        case 2: if (move2 != null) move2("move", id, x, y, dx, dy); break;
                //        case 3: if (move3 != null) move3("move", id, x, y, dx, dy); break;
                //        case 4: if (move4 != null) move4("move", id, x, y, dx, dy); break;
                //    }
                //}
                else if (touch.phase == TouchPhase.Ended)
                {

                Debug.Log(touch_fingerId);

                switch (id)
                    {
                        case 0: if (end0 != null) end0("end", id, x, y, dx, dy); break;
                        case 1: if (end1 != null) end1("end", id, x, y, dx, dy); break;
                        case 2: if (end2 != null) end2("end", id, x, y, dx, dy); break;
                        case 3: if (end3 != null) end3("end", id, x, y, dx, dy); break;
                        case 4: if (end4 != null) end4("end", id, x, y, dx, dy); break;
                    }

                if (b_touch)// 터치가 트루일때만. 들어온다. 
                    PlayerMgr.player.Call_Magic_DefaltBall();


                TouchDisEnable();
            }


            //PlayerMgr.player.Call_Magic_DefaltBall();
        }


      

    }


	void OnEnable()
	{
		begin0 += onTouch;  // 초기화 함수를OnTouch 타입으로  정의 한 것이랑 같다.   
		end0 += onTouch;
		move0 += onTouch;
		
		begin1 += onTouch;
		end1 += onTouch;
		move1 += onTouch;
		
		begin2 += onTouch;
		end2 += onTouch;
		move2 += onTouch;
		
		begin3 += onTouch;
		end3 += onTouch;
		move3 += onTouch;
		
		begin4 += onTouch;
		end4 += onTouch;
		move4 += onTouch;


	}
	
	void OnDisable()
	{
		begin0 -= onTouch;  // 초기화 함수를OnTouch 타입으로  정의 한 것이랑 같다.   
		end0 -= onTouch;
		move0 -= onTouch;
		
		begin1 -= onTouch;
		end1 -= onTouch;
		move1 -= onTouch;
		
		begin2 -= onTouch;
		end2 -= onTouch;
		move2 -= onTouch;
		
		begin3 -= onTouch;
		end3 -= onTouch;
		move3 -= onTouch;
		
		begin4 -= onTouch;
		end4 -= onTouch;
		move4 -= onTouch;
	
	
	}
	void onTouch( string type, int id, float x, float y, float dx, float dy){


		switch( type ){
		case"begin"://Debug.Log(  "id"+id+"begin:" + x + "," + y +", d:" + dx +","+dy );  
			beginPos [id].x = x;
			beginPos [id].y = y;
			//AnyPos[id].x = x; 
			//AnyPos[id].y = y;
			Begin_Touch[id] = true;
			Move_Touch[id] = false;
			End_Touch[id] = false;
			Any_touch[id] = true;
			break;
		case"move"://Debug.Log(  "id"+id+"Move:" + x + "," + y +", d:" + dx +","+dy ); 
			//MovsPos [id].x = x;
			//MovsPos [id].y = y;
			//AnyPos[id].x = x; 
			//AnyPos[id].y = y;
			Begin_Touch[id] = false;
			Move_Touch[id] = true;
			End_Touch[id] = false;
			Any_touch[id] = true;
			break;
		case"end": //Debug.Log(  "id"+id+"end:" + x + "," + y +", d:" + dx +","+dy ); 
			EndPos[id].x = x;
			EndPos[id].y = y;
			Begin_Touch[id] = false;
			Move_Touch[id] = false;
			End_Touch[id] = true;
			Any_touch[id] = false;
            
                break;
		
	
		}

       
    }
	public float CurrentTouchBeginPos(int id)
	{

		float _x = beginPos [id].x;
		//float _y = beginPos [id].y;
		return  _x;
	}

    public void InitBegin_Touch()
    {
        for (int i = 0; i < Begin_Touch.Length; i++)
        {
            Begin_Touch[i] = false;

        }

    }

    public bool b_touch;  // 터치 패널만 적용.
    public void TouchOn()
    {
        b_touch = true;

    }

    public void TouchDisEnable()
    {

        


        b_touch = false;
     
    }

}
