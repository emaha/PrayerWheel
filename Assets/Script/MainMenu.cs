using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour {

	private int menu = 0 ;
	private int wheelMenu = 0;
	private int backMenu = 0;
	private int info = 0;
	private Texture2D tex;
	public static string url;
	public FileBrowser br;


	void Start()
	{
		if (url != null)
			setFile ();
	}

	void setTexture(int num)
	{
		string s = "Wheel" + num.ToString ();
		Debug.Log (s);
		tex = Resources.Load(s) as Texture2D;
		gameObject.renderer.material.mainTexture = tex;
	}

	void setBackground(int num)
	{
		GameObject go = GameObject.Find("Cube");
		string s = "Back" + num.ToString ();
		Debug.Log (s);
		tex = Resources.Load(s) as Texture2D;
		go.renderer.material.mainTexture = tex;
	}

	void OnFileSelected(FileInfo info)
	{
		url = info.path;//ToString();
		setFile ();
	}

	void OnBrowseCancel()
	{
		url = null;
	}

	void OnFileChange()
	{

	}


	void setFile()
	{
		url = url.Replace("\\" , "/");
		url = "file:///"+url;
		//url = "file:///c:/2.png";
		Debug.Log (url);

		WWW www = new WWW(url);
		gameObject.renderer.material.mainTexture = www.texture;
	}


	void OnGUI()
	{
		if(GUI.Button (new Rect(0,10,25,150),">"))
		{
			menu = Mathf.Abs(--menu);
			info = 0;
		}
		if (menu==1) 
		{
			if(GUI.Button (new Rect(30,10,150,50),"Change prayer wheel"))
			{
				info = 0;
				wheelMenu = 1;
				backMenu = 0;
			}
	
			if(GUI.Button (new Rect(30,70,150,50),"Change background"))
			{
				info = 0;
				wheelMenu = 0;
				backMenu = 1;
			}

			if(GUI.Button (new Rect(30,150,150,50),"About us"))
			{
				wheelMenu = 0;
				backMenu = 0;
				menu = 0;
				info=1;
			}

			if(GUI.Button (new Rect(30,230,150,50),"Exit"))
			{
				Application.Quit();
			}
		}
		else
		{		
			wheelMenu = 0;
			backMenu = 0;
		}

		if (wheelMenu==1) 
		{
			backMenu = 0;
			if(GUI.Button (new Rect(190,10,150,50),"Avalokiteshvara")){setTexture(1);}
			if(GUI.Button (new Rect(190,70,150,50),"Mandala Offering")){setTexture(2);}
			if(GUI.Button (new Rect(190,130,150,50),"Medicine Budda")){setTexture(3);}
			if(GUI.Button (new Rect(190,190,150,50),"Refuge and Bodhichitta")){setTexture(4);}
			if(GUI.Button (new Rect(190,250,150,50),"Togel and Treckcho 1")){setTexture(5);}
			if(GUI.Button (new Rect(190,310,150,50),"Togel and Treckcho 2")){setTexture(6);}
			if(GUI.Button (new Rect(190,370,150,50),"Togel and Treckcho 3")){setTexture(7);}
			if(GUI.Button (new Rect(190,430,150,50),"Yungdrung Bon")){setTexture(8);}
			if(GUI.Button (new Rect(190,490,150,50),"LOAD..."))
			{
				if (!br.isShowing)
					br.Show (@"c:\", this, FileSelectMode.File);
			}



		}

		if (backMenu==1) 
		{
			wheelMenu = 0;
			if(GUI.Button (new Rect(190,10,175,50),"Altai  - Chuyskiy spine")) {setBackground(1);}
			if(GUI.Button (new Rect(190,70,175,50),"Altai - Akkem lake")) {setBackground(2);}
			if(GUI.Button (new Rect(190,130,175,50),"Altai - Chuya river")){setBackground(3);}
			if(GUI.Button (new Rect(190,190,175,50),"Altai - Inegeni")){setBackground(4);}
			if(GUI.Button (new Rect(190,250,175,50),"Altai - Katuyaryk")){setBackground(5);}
			if(GUI.Button (new Rect(190,310,175,50),"Broad Sky")){setBackground(6);}

			if(GUI.Button (new Rect(190,370,175,50),"Altai - Belukha Mountain")){setBackground(13);}

			if(GUI.Button (new Rect(375,10,175,50),"Nepal -  Muktinath")){setBackground(7);}
			if(GUI.Button (new Rect(375,70,175,50),"Nepal -  Muktinath valley")){setBackground(8);}
			if(GUI.Button (new Rect(375,130,175,50),"Nepal - Kagbeni valley")){setBackground(9);}
			if(GUI.Button (new Rect(375,190,175,50),"Nepal - Katmandu  Bodnath")){setBackground(10);}
			if(GUI.Button (new Rect(375,250,175,50),"Nepal - road in Muktinath")){setBackground(11);}
			if(GUI.Button (new Rect(375,310,175,50),"Nepal - Svayambodnath")){setBackground(12);}

			if(GUI.Button (new Rect(375,370,175,50),"Altai - Teletskoe lake")){setBackground(14);}
		}

		if (info==1) 
		{
			backMenu = 0;
			wheelMenu = 0;

			GUI.Box(new Rect(120, 100,Screen.width-240, 25), "About Prayer Wheel (FreeWare)");
			GUI.Box(new Rect(120, 125,Screen.width-240, Screen.height-145), "You can send any quastions and great ideas to e-mail: prayerwheel@mail.ru\n"+
			"This is the number of Qiwi wallet for Your sincere offerings: 9511694975\n\n" +
			"Photographies: studio House winds http://domvetra.com/");
			if(GUI.Button(new Rect(Screen.width-230,Screen.height-55,100,25), "Close")){info=0;}
			
		}






	}
}
