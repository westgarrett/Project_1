
public class Square_Entry {
	public static int value;
	public static boolean permanent_state;

	public Square_Entry(int given_value, boolean given_state){
		value = given_value;
		permanent_state = given_state;
	}
	
	public Square_Entry(){
		value = 0;
		permanent_state = false;
	}
	
	public int value(){
		return value;
	}
	
	public boolean permanent(){
		return permanent_state;
	}
	
	public void set_value(int given_value){
		value = given_value;
	}
	
	public void set_permanent_state(boolean given_state){
		permanent_state = given_state;
	}
	
//	public String print(){
//		String return_string = "";
//		return_string += value;
//		return return_string;
//	}
}
