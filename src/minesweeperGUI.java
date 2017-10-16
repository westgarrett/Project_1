import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;

public class minesweeperGUI extends JFrame implements MouseListener {
    minesweeper game;
    JPanel gamePanel;
    JPanel statusPanel;
    JLabel statusLabel;
    minesweeperGUI.mineButton[][] mb;
    Color backGround;
    int numRows = 9;
    int numCols = 9;
    Icon mineIcon = new ImageIcon(this.getClass().getResource("mine.jpg"));
    Icon minexIcon = new ImageIcon(this.getClass().getResource("minex.jpg"));
    Icon mineredIcon = new ImageIcon(this.getClass().getResource("minered.jpg"));
    Icon flagIcon = new ImageIcon(this.getClass().getResource("flag.jpg"));

    public minesweeperGUI() {
        this.backGround = Color.WHITE;
        JMenu var1 = new JMenu("File");
        var1.setMnemonic('F');
        JMenuItem var2 = new JMenuItem("New");
        var2.setMnemonic('N');
        var1.add(var2);
        var2.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent var1) {
                minesweeperGUI.this.newGame();
            }
        });
        JMenuItem var3 = new JMenuItem("Exit");
        var3.setMnemonic('X');
        var1.add(var3);
        var3.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent var1) {
                System.exit(0);
            }
        });
        JMenuBar var4 = new JMenuBar();
        this.setJMenuBar(var4);
        var4.add(var1);
        this.gamePanel = new JPanel();
        this.gamePanel.setLayout(new GridLayout(this.numRows, this.numCols));
        this.statusPanel = new JPanel();
        this.statusPanel.setLayout(new FlowLayout(1));
        this.statusLabel = new JLabel();
        this.statusLabel.setFont(new Font("Serif", 1, 24));
        this.statusPanel.add(this.statusLabel);
        Container var5 = this.getContentPane();
        var5.setLayout(new BorderLayout());
        var5.add(this.statusPanel, "North");
        var5.add(this.gamePanel, "Center");
        this.gamePanel.addMouseListener(this);
        this.game = new minesweeper(this.numRows, this.numCols);
        this.mb = new minesweeperGUI.mineButton[this.numRows][this.numCols];

        for(int var6 = 0; var6 < this.numRows; ++var6) {
            for(int var7 = 0; var7 < this.numCols; ++var7) {
                this.mb[var6][var7] = new minesweeperGUI.mineButton(var6, var7);
                this.mb[var6][var7].addMouseListener(this);
                this.gamePanel.add(this.mb[var6][var7]);
            }
        }

        this.statusLabel.setText("New Game");
        this.setTitle("Minesweeper");
        this.setContentPane(var5);
        this.setSize(400, 300);
        this.show();
    }

    private void newGame() {
        this.game = new minesweeper(this.numRows, this.numCols);
        this.updateGame();
        this.statusLabel.setText("New Game");
    }

    public void updateGame() {
        for(int var1 = 0; var1 < this.numRows; ++var1) {
            for(int var2 = 0; var2 < this.numCols; ++var2) {
                switch(this.game.getBoard(var1, var2)) {
                    case ' ':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '!':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setBackground(this.backGround);
                        this.mb[var1][var2].setIcon(this.mineredIcon);
                    case '"':
                    case '#':
                    case '$':
                    case '%':
                    case '&':
                    case '\'':
                    case '(':
                    case ')':
                    case '+':
                    case ',':
                    case '.':
                    case '/':
                    case '0':
                    case '9':
                    case ':':
                    case ';':
                    case '<':
                    case '=':
                    case '>':
                    case '@':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'G':
                    case 'H':
                    case 'I':
                    case 'J':
                    case 'K':
                    case 'L':
                    case 'M':
                    case 'N':
                    case 'O':
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case 'T':
                    case 'U':
                    case 'V':
                    case 'W':
                    default:
                        break;
                    case '*':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setBackground(this.backGround);
                        this.mb[var1][var2].setIcon(this.mineIcon);
                        break;
                    case '-':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setBackground(this.backGround);
                        this.mb[var1][var2].setIcon(this.minexIcon);
                        break;
                    case '1':
                        this.mb[var1][var2].setText("1");
                        this.mb[var1][var2].setForeground(Color.blue);
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '2':
                        this.mb[var1][var2].setText("2");
                        this.mb[var1][var2].setForeground(Color.green);
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '3':
                        this.mb[var1][var2].setText("3");
                        this.mb[var1][var2].setForeground(Color.red);
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '4':
                        this.mb[var1][var2].setText("4");
                        this.mb[var1][var2].setForeground(Color.orange);
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                        this.mb[var1][var2].setText(Integer.toString(this.game.getBoard(var1, var2)));
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground(this.backGround);
                        break;
                    case '?':
                        this.mb[var1][var2].setText("?");
                        this.mb[var1][var2].setForeground(Color.blue);
                        this.mb[var1][var2].setIcon((Icon)null);
                        break;
                    case 'F':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setIcon(this.flagIcon);
                        break;
                    case 'X':
                        this.mb[var1][var2].setText("");
                        this.mb[var1][var2].setIcon((Icon)null);
                        this.mb[var1][var2].setBackground((Color)null);
                }
            }
        }

        this.statusLabel.setText(this.game.getStatus());
        if (this.game.getStatus().equalsIgnoreCase("play")) {
            this.statusLabel.setForeground(Color.black);
            this.statusLabel.setText("Game in Progress ...");
        } else if (this.game.getStatus().equalsIgnoreCase("win")) {
            this.statusLabel.setForeground(new Color(10, 104, 17));
            this.statusLabel.setText("You Win!  : - )");
        } else {
            this.statusLabel.setForeground(Color.red);
            this.statusLabel.setText("You Lose  : - (");
        }

    }

    public static void main(String[] var0) {
        minesweeperGUI var1 = new minesweeperGUI();
        var1.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent var1) {
                System.exit(0);
            }
        });
    }

    public void mouseClicked(MouseEvent var1) {
        minesweeperGUI.mineButton var2 = (minesweeperGUI.mineButton)var1.getSource();
        if (var1.getButton() == 1) {
            this.game.markTile(var2.getRow(), var2.getCol(), 0);
        } else if (var1.getButton() == 3) {
            switch(this.game.getTiles(var2.getRow(), var2.getCol())) {
                case 1:
                    this.game.markTile(var2.getRow(), var2.getCol(), 3);
                    break;
                case 2:
                    this.game.markTile(var2.getRow(), var2.getCol(), 1);
                    break;
                case 3:
                    this.game.markTile(var2.getRow(), var2.getCol(), 2);
            }
        }

        this.updateGame();
    }

    public void mousePressed(MouseEvent var1) {
    }

    public void mouseReleased(MouseEvent var1) {
    }

    public void mouseEntered(MouseEvent var1) {
    }

    public void mouseExited(MouseEvent var1) {
    }

    private class mineButton extends JButton {
        int r;
        int c;

        public mineButton(int var2, int var3) {
            this.r = var2;
            this.c = var3;
        }

        public int getRow() {
            return this.r;
        }

        public int getCol() {
            return this.c;
        }
    }
}
