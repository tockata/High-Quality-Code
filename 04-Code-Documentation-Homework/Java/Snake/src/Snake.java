import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * This class defines Snake object and its properties
 */
public class Snake {
	LinkedList<Point> body = new LinkedList<Point>();
	private Color color;
	private int velocityX;
    private int velocityY;

    /**
     * Class constructor
     */
	public Snake() {
		color = Color.GREEN;
		body.add(new Point(300, 100));
		body.add(new Point(280, 100));
		body.add(new Point(260, 100));
		body.add(new Point(240, 100));
		body.add(new Point(220, 100));
		body.add(new Point(200, 100));
		body.add(new Point(180, 100));
		body.add(new Point(160, 100));
		body.add(new Point(140, 100));
		body.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}

    /**
     * Draws snake body
     * @param g
     */
	public void drawSnake(Graphics g) {
		for (Point point : this.body) {
			point.drawSquareFromPoint(g, color);
		}
	}

    /**
     * Checks head`s new position for collisions with snake itself, borders and apple
     * and sets its position
     */
	public void tick() {
		Point newSnakeHeadPosition = new Point((body.get(0).getX() + velocityX), (body.get(0).getY() + velocityY));
		
		if (newSnakeHeadPosition.getX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (newSnakeHeadPosition.getX() < 0) {
			Game.gameRunning = false;
		} else if (newSnakeHeadPosition.getY() < 0) {
			Game.gameRunning = false;
		} else if (newSnakeHeadPosition.getY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.getApplePosition().equals(newSnakeHeadPosition)) {
			body.add(Game.apple.getApplePosition());
			Game.apple = new Apple(this);
			Game.score += 50;
		} else if (body.contains(newSnakeHeadPosition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = body.size()-1; i > 0; i--) {
			body.set(i, new Point(body.get(i-1)));
		}	
		body.set(0, newSnakeHeadPosition);
	}

    /**
     * Properties for VelX and VelY
     */
	public int getVelX() {
		return velocityX;
	}

	public void setVelX(int velX) {
		this.velocityX = velX;
	}

	public int getVelY() {
		return velocityY;
	}

	public void setVelY(int velY) {
		this.velocityY = velY;
	}
}
