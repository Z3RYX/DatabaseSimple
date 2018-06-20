/*
 * Created by SharpDevelop.
 * User: ZeRyX
 * Date: 29.05.2018
 * Time: 21:18
 */
using System;

namespace DatabaseSimple {
    class Program {
        static void Main(string[] args) {
            //Instanciating Database
            Database db = new Database();
            
            //adding new data (default in this case) to Database with db.add(Title,Info);
	    db.add("Default","Default entry");
            
            //getting user input
            while(true) {
            	string input = Console.ReadLine();
            	Console.Clear();
		    
            	if(input=="/end" || input=="/exit") {
			break;
		}
		    
            	if(input.Contains("/add")) {
			Console.WriteLine("Enter title and then the info");
            		db.add(Console.ReadLine(), Console.ReadLine());
			Console.Clear();
               		continue;
		}
		    
            	if(input.Length>0) {
            		db.search(input);
		}
		    
            	else {
            		Console.WriteLine("No input given");
		}
	    }
	}
    class Database {
        public int ID = 0;
        string[] dataBaseID = new string[1000];
        string[,] dataBase = new string[1000,2];
       
        //assign Database arrays with default
        public Database() {
            for(int i=0;i<1000;i++) {
                dataBaseID[i] = "n/a";
                dataBase[i,0] = "n/a";
                dataBase[i,1] = "n/a";
	    }
	}
       
        //add data to dataBase
        public void add(string name = "n/a", string info = "n/a") {
            ID++;
            dataBaseID[ID-1] = Convert.ToString(ID);
           
            dataBase[ID-1,0] = name;
            dataBase[ID-1,1] = info;
	}
       
       //get data from dataBase
       public void search(string inp) {
            int searchCount = 0;
            for(int x=0;x<1000;x++) {
                if(dataBaseID[x].Contains(inp)) {
                    if(dataBaseID[x]=="n/a") {
			    continue;
		    }
                    Console.WriteLine("Title: " + dataBase[x,0]);
                    Console.WriteLine("Info: " + dataBase[x,1]);
		    //For debugging
                    //Console.WriteLine("ID: " + dataBaseID[x] + "\n\n");
                    searchCount++;
		}
                else if(dataBase[x,0].Contains(inp)) {
                    if(dataBaseID[x]=="n/a") {
			    continue;
		    }
                    Console.WriteLine("Title: " + dataBase[x,0]);
                    Console.WriteLine("Info: " + dataBase[x,1]);
		    //For debugging
                    //Console.WriteLine("ID: " + dataBaseID[x] + "\n\n");
                    searchCount++;
		}
                else {
		}
	    }
            if(searchCount==0) {
		    Console.WriteLine("Nothing found");
	    }
        }
    }
}
