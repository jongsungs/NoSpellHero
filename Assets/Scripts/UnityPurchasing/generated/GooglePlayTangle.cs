// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("jg5EIAMwgroGyHBa66k4vA7vBPQDgI6BsQOAi4MDgICBOG30p5mUOWBjnFshSTRJEHRE3wYXwEtoOLAkoPWfpQ/2WpnXJClp3Gaarwh6StOxMAbSQIct3s44eKkvvDcSQhA0/rEDgKOxjIeIqwfJB3aMgICAhIGCBojEgZRaGYkQcVlthomv7o+/xCAiohesWjOaB34bKUE5TGYjsBMJZgx3Fp3p3teEOF5w8sSNC7Yf/ZgblVFMTxKIWFOlbnv8V/lB/q0GYph3IQF0PSkTQgfuil91G+eP1gEy/tBZQdjDGpbIAZpngNBZDUqEzKZFwdFyvwzKtltEyVhmm0JGHMToRPr1tLNSW9eLbHgdGJU+2caYohXLzKnGUGx9h5ov6IOCgIGA");
        private static int[] order = new int[] { 3,1,11,7,5,7,6,9,10,13,13,13,12,13,14 };
        private static int key = 129;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
