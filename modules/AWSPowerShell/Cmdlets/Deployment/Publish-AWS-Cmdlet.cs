using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Threading;
using System.IO;

using Amazon.PowerShell.Common;
using Amazon.Runtime;

using AWSDeployment;
using Amazon.Util;

using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using System.Security;
using System.Runtime.InteropServices;

namespace Amazon.PowerShell.Cmdlets.Deployment
{
    /// <summary>
    /// <para>
    /// Publishes a web deployment archive to the AWS cloud. The deployment can be submitted to
    /// either the AWS CloudFormation or AWS Elastic Beanstalk services. If the deployment is to
    /// AWS CloudFormation, a CloudFormation 'Stack' instance is emitted to the pipeline. For
    /// deployments to AWS Elastic Beanstalk, an Elastic Beanstalk 'EnvironmentDescription' instance 
	/// is emitted.
    /// </para>
    /// <para>
    /// The deployment settings can be controlled using either a configuration file, in a similar
    /// manner to the awsdeploy.exe tool or settings can be supplied using a hash table instance
    /// in conjunction with the ConfigurationSettings parameter. If a configuration file and
    /// hash table settings are used, the hash table settings override settings contained in the
    /// configuration file.
    /// </para>
    /// <para>
    /// Using the Template parameter in conjunction with the ConfigurationSettings it is also 
    /// possible to perform deployments without the need for a configuration file.
    /// </para>
    /// </summary>
    [Cmdlet(VerbsData.Publish, "AWS", DefaultParameterSetName = "configFileParamSet")]
    [AWSCmdlet("Publishes a web deployment archive to either AWS CloudFormation or AWS Elastic Beanstalk.")]
    public class PublishAWSCmdlet : BaseCmdlet
    {
        const string configFileParamSet = "configFileParamSet";
        const string templateParamSet = "templateParamSet";

        DeploymentJob _job = new DeploymentJob();

        /// <summary>
        /// Gets and sets the name of the configuration file to use.
        /// </summary>
        [Alias("CF")]
        [Parameter(ParameterSetName = configFileParamSet, Mandatory = true, Position = 0)]
        public String ConfigurationFile { get; set; }

        /// <summary>
        /// Template identifies the AWS CloudFormation template to use, or can be used
        /// to specify that the deployment should target AWS Elastic Beanstalk.
        /// </summary>
        [Alias("T")]
        [Parameter(ParameterSetName = templateParamSet, Mandatory = true, Position = 0)]
        public string Template { get; set; }

        /// <summary>
        /// Causes all but error messages from the deployment to be squelched.
        /// </summary>
        [Alias("S")]
        [Parameter]
        public SwitchParameter Silent
        {
            get { return _silent; }
            set { _silent = value; }
        }
        bool _silent;

        /// <summary>
        /// Waits for the deployment process to complete before returning to the shell.
        /// Note that AsJob implies /W for the child job that is launched to perform the 
        /// actual deployment.
        /// </summary>
        [Alias("W")]
        [Parameter]
        public SwitchParameter Wait
        {
            get { return _wait; }
            set { _wait = value; }
        }
        bool _wait;

        /// <summary>
        /// Redeploys the application to an existing CloudFormation stack or to an
        /// existing or new Elastic Beanstalk environment.
        /// </summary>
        [Alias("R")]
        [Parameter]
        public SwitchParameter Redeploy
        {
            get { return _redeploy; }
            set { _redeploy = value; }
        }
        bool _redeploy;

        /// <summary>
        /// Specifies a log file to which deployment processing output will be captured.
        /// </summary>
        [Alias("L", "Log")]
        [Parameter]
        public string LogFile { get; set; }

        /// <summary>
        /// Specify the AsJob parameter. This parameter indicates 
        /// whether the cmdlet should perform the deployment internally 
        /// (and optionally wait for completion depending on the -Wait 
        /// parameter) or return a Job object that performs the deployment.        
        /// </summary>
        [Parameter]
        private SwitchParameter AsJob
        {
            get { return _asJob; }
            set { _asJob = value; }
        }
        bool _asJob;

        /// <summary>
        /// Hashtable of one or more key:value pairs.
        /// If used in conjunction with the -ConfigurationFile parameter, the table contents
        /// override already defined values in the configuration file.
        /// If used with the -Template parameter, the table supplies values that would normally
        /// be specified within the configuration file.
        /// </summary>
        [Alias("Settings", "CS")]
        [Parameter]
        public Hashtable ConfigurationSettings { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ValidateArguments())
                return;

            var jobContext = new JobExecutionContext 
            { 
                Session = SessionState,
                DeploymentCredentials = this.CurrentCredentials,
                Region = this.Region,
                AsJob = false, //this.AsJob.IsPresent,
                ConfigurationFile = this.ConfigurationFile,
                Template = this.Template,
                Silent = this.Silent.IsPresent,
                Verbose = (bool)GetVariableValue("Verbose", false),
                Wait = /*this.AsJob.IsPresent ||*/ this.Wait.IsPresent,
                LogFile = this.LogFile,
                Redeploy = this.Redeploy.IsPresent,
                Parameters = this.ConfigurationSettings
            };

            if (_asJob)
            {
                // Add the job definition to the job repository, 
                // return the job object, and then create the thread 
                // used to run the job.
                JobRepository.Add(_job);
                WriteObject(_job);
                ThreadPool.QueueUserWorkItem(JobWorkItem, jobContext);
            }
            else
            {
                _job.ProcessJob(jobContext);
                foreach (PSObject p in _job.Output)
                {
                    WriteObject(p);
                }
            }
        }

        void JobWorkItem(object state)
        {
            _job.ProcessJob(state as JobExecutionContext);
        }

        /// <summary>
        /// Ensure that the basic arguments supplied to the cmdlet make sense,
        /// </summary>
        /// <returns>false if the command should stop due to invalid parameters</returns>
        bool ValidateArguments()
        {
            if (!string.IsNullOrEmpty(ConfigurationFile))
            {
                string fileToTest;
                if (Path.IsPathRooted(ConfigurationFile))
                    fileToTest = ConfigurationFile;
                else
                    fileToTest = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path,
                                              ConfigurationFile);

                if (!File.Exists(fileToTest))
                {
                    var err = new ErrorRecord(new FileNotFoundException(String.Format("Configuration file not found: {0}",
                                                                                      fileToTest)),
                                              "Missing Configuration File",
                                              ErrorCategory.InvalidArgument,
                                              null);
                    WriteError(err);
                    return false;
                }
            }
            else
            {
            }

            return true;
        }

    }

    internal class DeploymentJob : Job
    {
        JobExecutionContext _jobContext;

        internal DeploymentJob()
        {
            SetJobState(JobState.NotStarted);
        }

        public override string StatusMessage
        {
            get 
            {
                return ""; 
            }
        }

        public override bool HasMoreData
        {
            get { return _hasMoreData; }
        }
        bool _hasMoreData = true;

        public override string Location
        {
            get { return ""; }
        }

        public override void StopJob()
        {
            throw new NotImplementedException();
        }

        // this is basically the internals of awsdeploy.exe without the arg processing and with the ability
        // to skip usage of a config file...
        internal void ProcessJob(JobExecutionContext jobContext)
        {
            _jobContext = jobContext;

            SetJobState(JobState.Running);

            // leaving this out for now, as setting it will affect the entire host ps shell
            //AWSSDKUtils.SetUserAgent("AWSToolkit.DeploymentTool", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            var observer = SetDeploymentObserver();
            
            try
            {
                var deployment = PrepareDeploymentEngine(observer);
                object deployedInstance = null;

                // not sure if we want to support UpdateStack mode at present
                if (_jobContext.Redeploy)
                {
                    deployedInstance = deployment.Redeploy();

                    //if (updateStack)
                    //    deployment.UpdateStack();
                }
                //else if (updateStack)
                //    deployment.UpdateStack();
                else
                    deployedInstance = deployment.Deploy();

                if (_jobContext.Wait)
                {
                    observer.Status("Waiting for deployment to complete.");
                    deployment.WaitForCompletion();
                }

                if (!jobContext.AsJob)
                {
                    Output.Add(new PSObject(deployedInstance));
                }
                else
                {
                    ChildJobs[0].Output.Add(new PSObject(deployedInstance));
                }

                SetJobState(JobState.Completed);
            }
            catch (Exception exc)
            {
                // The deployment class itself will message about why the deployment failed, but it 
                // re-throws the exception.
                WriteError(exc, ErrorCategory.OperationStopped, string.Empty);
                SetJobState(JobState.Failed);
            }
            finally
            {
                _hasMoreData = false;
            }
        }

        /// <summary>
        /// Construct and initialize an appropriate deployment engine based on the supplied
        /// parameters. This may involve reading a configuration file and construction from
        /// information contained, or direct construction and population from cmdlet
        /// parameters.
        /// </summary>
        /// <param name="observer">Observer to attach to the constructed engine</param>
        /// <returns>Created and initialized engine</returns>
        DeploymentEngineBase PrepareDeploymentEngine(DeploymentObserver observer)
        {
            return !string.IsNullOrEmpty(_jobContext.ConfigurationFile) 
                ? DeploymentEngineFromConfiguration(observer) : DeploymentEngineFromParameters(observer);
        }

        /// <summary>
        /// Constructs a deployment engine based on information present in the
        /// supplied configuration file.
        /// </summary>
        /// <param name="observer">Observer to attach to the constructed engine</param>
        /// <returns>Created and initialized engine</returns>
        DeploymentEngineBase DeploymentEngineFromConfiguration(DeploymentObserver observer)
        {
            string fqConfigurationFile = PSHelpers.PSPathToAbsolute(_jobContext.Session.Path, _jobContext.ConfigurationFile);

            var parameters = HashToDictionary(_jobContext.Parameters);

            var credentials = _jobContext.DeploymentCredentials.GetCredentials();
            if (!parameters.ContainsKey("AWSAccessKey"))
                parameters.Add("AWSAccessKey", credentials.AccessKey);
            if (!parameters.ContainsKey("AWSSecretKey"))
                parameters.Add("AWSSecretKey",
                               credentials.UseSecureStringForSecretKey
                                   ? ExtractSecretFromSecureString(credentials.SecureSecretKey)
                                   : credentials.ClearSecretKey);
            if (!parameters.ContainsKey("Region"))
                parameters.Add("Region", _jobContext.Region.SystemName);

            var deployment = DeploymentConfigurationReader.ReadDeploymentFromFile(fqConfigurationFile,
                                                                                  parameters,
                                                                                  _jobContext.Redeploy,
                                                                                  observer);

            return deployment;
        }

        /// <summary>
        /// Extracts a secure string
        /// </summary>
        /// <param name="secureKey">The secure string to extract</param>
        /// <returns>The secure string </returns>
        static string ExtractSecretFromSecureString(SecureString secureKey)
        {
            IntPtr bstr = IntPtr.Zero;

            try
            {
                var Ksecret = new char[secureKey.Length];
                bstr = Marshal.SecureStringToBSTR(secureKey);
                Marshal.Copy(bstr, Ksecret, 0, secureKey.Length);
                return new string(Ksecret);
            }
            finally
            {
                if (bstr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr);
            }
        }

        /// <summary>
        /// Constructs a deployment engine based on information present in the
        /// parameters to the host cmdlet.
        /// </summary>
        /// <param name="observer">Observer to attach to the constructed engine</param>
        /// <returns>Created and initialized engine</returns>
        DeploymentEngineBase DeploymentEngineFromParameters(DeploymentObserver observer)
        {
            var template = _jobContext.Template.Trim();
            var deploymentService = template.EndsWith("beanstalk", StringComparison.InvariantCultureIgnoreCase)
                ? DeploymentEngineFactory.ElasticBeanstalkServiceName
                : DeploymentEngineFactory.CloudFormationServiceName;

            var deployment = DeploymentEngineFactory.CreateEngine(deploymentService);
            deployment.Observer = observer;

            var parameterSets = new ConfigurationParameterSets();

            var credentials = _jobContext.DeploymentCredentials.GetCredentials();
            parameterSets.SetParameter("AWSAccessKey", credentials.AccessKey, -1);
            parameterSets.SetParameter("AWSSecretKey",
                                       credentials.UseSecureStringForSecretKey
                                           ? ExtractSecretFromSecureString(credentials.SecureSecretKey)
                                           : credentials.ClearSecretKey, -1);
            parameterSets.SetParameter("Region", _jobContext.Region.SystemName, -1);

            if (_jobContext.Parameters != null)
            {
                foreach (string key in _jobContext.Parameters.Keys)
                {
                    parameterSets.SetParameter(key, _jobContext.Parameters[key] as string, -1);
                }
            }

            var parameterSetNames = parameterSets.ParameterSetNames;
            foreach (var setName in parameterSetNames)
            {
                var parameters = parameterSets[setName];
                foreach (var paramKey in parameters.Keys)
                {
                    DeploymentConfigurationReader.ProcessLine(deployment, setName, paramKey, parameters[paramKey]);
                }
            }

            if (deployment.PostProcessConfigurationSettings(_jobContext.Redeploy) != DeploymentEngineBase.SUCCESS)
                throw new Exception("Deployment failed during post-processing of configuration settings.");

            return deployment;
        }

        /// <summary>
        /// Maps from the Hashtable used by PowerShell to the Dictionary used by our deployment lib
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        static Dictionary<string, string> HashToDictionary(Hashtable hash)
        {
            var d = new Dictionary<string, string>();
            if (hash != null)
            {
                foreach (string key in hash.Keys)
                {
                    d.Add(key, hash[key].ToString());
                }
            }

            return d;
        }

        DeploymentObserver SetDeploymentObserver()
        {
            if (_jobContext.Silent)
            {
                if (_jobContext.Verbose)
                    WriteProgress("Making best effort to be silent AND verbose...");

                return !string.IsNullOrEmpty(_jobContext.LogFile) 
                    ? new DeploymentToolLogObserver(_jobContext.LogFile) : new DeploymentObserver();
            }
            
            if (!string.IsNullOrEmpty(_jobContext.LogFile))
                return new DeploymentToolCombinedObserver(_jobContext.LogFile, this, _jobContext.Verbose);
            else
                return new DeploymentToolConsoleObserver(this, _jobContext.Verbose);
        }

        internal void WriteError(Exception errorException, ErrorCategory errorCategory, string messageFormat, params object[] list)
        {
            // note: the 'AWSDeploymentError' identifier cannot be changed after we RTM without 
            // powershell semantics considering it a new 'error'
            var er = new ErrorRecord(errorException, "AWSDeploymentError", errorCategory, null);
            if (_jobContext.AsJob)
                ChildJobs[0].Error.Add(er);
            else
                Error.Add(er);
        }

        internal void WriteProgress(string messageFormat, params object[] list)
        {
            var pr = new ProgressRecord(this.GetHashCode(), 
                                        "Deployment", 
                                        string.Format(messageFormat, list));
            if (_jobContext.AsJob)
                ChildJobs[0].Progress.Add(pr);
            else
                Progress.Add(pr);
        }
    }

    internal class JobExecutionContext
    {
        /// <summary>
        /// The session state of the invoking cmdlet
        /// </summary>
        public SessionState Session { get; set; }

        /// <summary>
        /// Credentials present on the command line or in the shell environment at the time the cmdlet was
        /// invoked and the job started
        /// </summary>
        public AWSCredentials DeploymentCredentials { get; set; }

        /// <summary>
        /// AWS region present on the command line or in the shell environment at the time the cmdlet was
        /// invoked and the job started
        /// </summary>
        public RegionEndpoint Region { get; set; }

        public bool AsJob { get; set; }

        /// <summary>
        /// Optional, name of the configuration file defining the deployment parameters
        /// </summary>
        public string ConfigurationFile { get; set; }

        /// <summary>
        /// Optional, name of the deployment template (if not using a configuration file)
        /// </summary>
        public string Template { get; set; }

        public bool Silent { get; set; }
        
        public bool Verbose { get; set; }
        
        /// <summary>
        /// If true, wait for the job to complete. -AsJob implies -Wait
        /// </summary>
        public bool Wait { get; set; }

        public string LogFile { get; set; }

        public bool Redeploy { get; set; }

        public Hashtable Parameters { get; set; }
    }

    #region Logger Implementations

    internal class DeploymentToolLogObserver : DeploymentObserver
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(typeof(CloudFormationDeploymentEngine));

        public DeploymentToolLogObserver(string logFilePath)
        {
            if (string.IsNullOrEmpty(logFilePath))
                throw new Exception("Can't create logfile with empty path");

            var fileAppender = new FileAppender();

            if (!Path.IsPathRooted(logFilePath))
                logFilePath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + logFilePath;

            fileAppender.File = logFilePath;

            var layout = new SimpleLayout();
            layout.ActivateOptions();
            fileAppender.Layout = layout;

            fileAppender.AppendToFile = File.Exists(logFilePath);

            fileAppender.ActivateOptions();
            BasicConfigurator.Configure(fileAppender);
        }

        public override void Status(string messageFormat, params object[] list)
        {
            LOGGER.InfoFormat(messageFormat, list);
        }

        public override void Info(string messageFormat, params object[] list)
        {
            LOGGER.InfoFormat(messageFormat, list);
        }

        public override void Warn(string messageFormat, params object[] list)
        {
            LOGGER.WarnFormat(messageFormat, list);
        }

        public override void Error(string messageFormat, params object[] list)
        {
            LOGGER.ErrorFormat(messageFormat, list);
        }
    }

    internal class DeploymentToolConsoleObserver : DeploymentObserver
    {
        public bool Verbose { get; set; }
        readonly DeploymentJob _hostJob;

        public DeploymentToolConsoleObserver(DeploymentJob hostJob, bool verbose)
        {
            this._hostJob = hostJob;
            Verbose = verbose;
        }

        public override void Status(string messageFormat, params object[] list)
        {
            _hostJob.WriteProgress(messageFormat, list);
        }

        public override void Info(string messageFormat, params object[] list)
        {
            if (Verbose)
                _hostJob.WriteProgress(messageFormat, list);
        }

        public override void Warn(string messageFormat, params object[] list)
        {
            _hostJob.WriteProgress("[Warning]: " + messageFormat, list);
        }

        public override void Error(string messageFormat, params object[] list)
        {
            // powershell sdk mandates that an exception object has to be raised
            _hostJob.WriteError(new Exception(), ErrorCategory.NotSpecified, messageFormat, list);
        }
    }

    internal class DeploymentToolCombinedObserver : DeploymentObserver
    {
        readonly DeploymentToolConsoleObserver _consoleObserver;
        readonly DeploymentToolLogObserver _logObserver;

        public DeploymentToolCombinedObserver(string logFilePath, DeploymentJob hostJob, bool verbose)
        {
            _consoleObserver = new DeploymentToolConsoleObserver(hostJob, verbose);
            _logObserver = new DeploymentToolLogObserver(logFilePath);
        }

        public override void Status(string messageFormat, params object[] list)
        {
            _consoleObserver.Status(messageFormat, list);
            _logObserver.Status(messageFormat, list);
        }

        public override void Info(string messageFormat, params object[] list)
        {
            _consoleObserver.Info(messageFormat, list);
            _logObserver.Info(messageFormat, list);
        }

        public override void Warn(string messageFormat, params object[] list)
        {
            _consoleObserver.Warn(messageFormat, list);
            _logObserver.Warn(messageFormat, list);
        }

        public override void Error(string messageFormat, params object[] list)
        {
            _consoleObserver.Error(messageFormat, list);
            _logObserver.Error(messageFormat, list);
        }
    }

    #endregion
}
