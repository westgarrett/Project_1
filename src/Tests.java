
public class Tests {

	public static void main(String[] args) {
		Print_Board_Tests();

	}
	
	public static void Print_Board_Tests(){
		String expected = "0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0\n0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0";
		int[][] input = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
		String output = Sudoku_Main.Convert_Board_To_String(input);
		if(expected.equals(output)){
			System.out.println("Convert_Board_To_String worked");
		}else{
			System.out.println("Convert_Board_To_String failed");
			System.out.println("Expected: \n" + expected);
			System.out.println("Output: \n" + output);
		}
	}

}
