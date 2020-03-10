namespace BaseUiSetup.JavaScriptScripts
{
	public class JavaScriptScripts
	{
		public const string WaitForAngular = @"
            var waitForAngular = function(rootSelector, callback) {
	            var el = document.querySelector(rootSelector);
	            try{
		            if (window.getAngularTestability){
			            window.getAngularTestability(el).whenStable(callback);
			            return;
		            }
		            if (!window.angular){
			            throw new Error('window.angular is undefined');
		            }
		            if (angular.getTestability) {
			            angular.getTestability(el).whenStable(callback);
		            }
		            else {
			            if (!angular.element(el).injector()) {
				            throw new Error();
			            }
			            angular.element(el).injector().get('$browser').notifyWhenNoOutstandingRequests(callback);
		            }
	            }
	            catch (error){
		            callback(error.message);
	            }
            };

            var rootSelector = arguments[0];
            var callback = arguments[1];

            waitForAngular(rootSelector, callback);
        ";

		public const string ResumeAngularBootstrap = "angular.resumeBootstrap(argumentsp[0].length ? arguments[0].split(',') : []);";
	}
}
