using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreScript {
	private static int m_leftScore, m_rightScore;

    public static int leftScore {
        get {return m_leftScore;}
        set {m_leftScore = value;}
    }

    public static int rightScore {
    	get {return m_rightScore;}
    	set {m_rightScore = value;}
    }
}
