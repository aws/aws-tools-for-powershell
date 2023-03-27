/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Creates a session for running calculations within a workgroup. The session is ready
    /// when it reaches an <code>IDLE</code> state.
    /// </summary>
    [Cmdlet("Start", "ATHSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Athena.Model.StartSessionResponse")]
    [AWSCmdlet("Calls the Amazon Athena StartSession API operation.", Operation = new[] {"StartSession"}, SelectReturnType = typeof(Amazon.Athena.Model.StartSessionResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.StartSessionResponse",
        "This cmdlet returns an Amazon.Athena.Model.StartSessionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartATHSessionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter EngineConfiguration_AdditionalConfig
        /// <summary>
        /// <para>
        /// <para>Contains additional notebook engine <code>MAP&lt;string, string&gt;</code> parameter
        /// mappings in the form of key-value pairs. To specify an Athena notebook that the Jupyter
        /// server will download and serve, specify a value for the <a>StartSessionRequest$NotebookVersion</a>
        /// field, and then add a key named <code>NotebookId</code> to <code>AdditionalConfigs</code>
        /// that has the value of the Athena notebook ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineConfiguration_AdditionalConfigs")]
        public System.Collections.Hashtable EngineConfiguration_AdditionalConfig { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive string used to ensure the request to create the session is
        /// idempotent (executes only once). If another <code>StartSessionRequest</code> is received,
        /// the same response is returned and another session is not created. If a parameter has
        /// changed, an error is returned.</para><important><para>This token is listed as not required because Amazon Web Services SDKs (for example
        /// the Amazon Web Services SDK for Java) auto-generate the token for users. If you are
        /// not using the Amazon Web Services SDK or the Amazon Web Services CLI, you must provide
        /// this token or the action will fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_CoordinatorDpuSize
        /// <summary>
        /// <para>
        /// <para>The number of DPUs to use for the coordinator. A coordinator is a special executor
        /// that orchestrates processing work and manages other executors in a notebook session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineConfiguration_CoordinatorDpuSize { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_DefaultExecutorDpuSize
        /// <summary>
        /// <para>
        /// <para>The default number of DPUs to use for executors. An executor is the smallest unit
        /// of compute that a notebook session can request from Athena.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineConfiguration_DefaultExecutorDpuSize { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The session description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_MaxConcurrentDpus
        /// <summary>
        /// <para>
        /// <para>The maximum number of DPUs that can run concurrently.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? EngineConfiguration_MaxConcurrentDpus { get; set; }
        #endregion
        
        #region Parameter NotebookVersion
        /// <summary>
        /// <para>
        /// <para>The notebook version. This value is supplied automatically for notebook sessions in
        /// the Athena console and is not required for programmatic session access. The only valid
        /// notebook version is <code>Athena notebook version 1</code>. If you specify a value
        /// for <code>NotebookVersion</code>, you must also specify a value for <code>NotebookId</code>.
        /// See <a>EngineConfiguration$AdditionalConfigs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookVersion { get; set; }
        #endregion
        
        #region Parameter SessionIdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The idle timeout in minutes for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionIdleTimeoutInMinutes")]
        public System.Int32? SessionIdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter WorkGroup
        /// <summary>
        /// <para>
        /// <para>The workgroup to which the session belongs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.StartSessionResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.StartSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkGroup parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkGroup' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkGroup' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkGroup), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ATHSession (StartSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.StartSessionResponse, StartATHSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkGroup;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            if (this.EngineConfiguration_AdditionalConfig != null)
            {
                context.EngineConfiguration_AdditionalConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EngineConfiguration_AdditionalConfig.Keys)
                {
                    context.EngineConfiguration_AdditionalConfig.Add((String)hashKey, (String)(this.EngineConfiguration_AdditionalConfig[hashKey]));
                }
            }
            context.EngineConfiguration_CoordinatorDpuSize = this.EngineConfiguration_CoordinatorDpuSize;
            context.EngineConfiguration_DefaultExecutorDpuSize = this.EngineConfiguration_DefaultExecutorDpuSize;
            context.EngineConfiguration_MaxConcurrentDpus = this.EngineConfiguration_MaxConcurrentDpus;
            #if MODULAR
            if (this.EngineConfiguration_MaxConcurrentDpus == null && ParameterWasBound(nameof(this.EngineConfiguration_MaxConcurrentDpus)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineConfiguration_MaxConcurrentDpus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotebookVersion = this.NotebookVersion;
            context.SessionIdleTimeoutInMinute = this.SessionIdleTimeoutInMinute;
            context.WorkGroup = this.WorkGroup;
            #if MODULAR
            if (this.WorkGroup == null && ParameterWasBound(nameof(this.WorkGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Athena.Model.StartSessionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EngineConfiguration
            var requestEngineConfigurationIsNull = true;
            request.EngineConfiguration = new Amazon.Athena.Model.EngineConfiguration();
            Dictionary<System.String, System.String> requestEngineConfiguration_engineConfiguration_AdditionalConfig = null;
            if (cmdletContext.EngineConfiguration_AdditionalConfig != null)
            {
                requestEngineConfiguration_engineConfiguration_AdditionalConfig = cmdletContext.EngineConfiguration_AdditionalConfig;
            }
            if (requestEngineConfiguration_engineConfiguration_AdditionalConfig != null)
            {
                request.EngineConfiguration.AdditionalConfigs = requestEngineConfiguration_engineConfiguration_AdditionalConfig;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize = null;
            if (cmdletContext.EngineConfiguration_CoordinatorDpuSize != null)
            {
                requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize = cmdletContext.EngineConfiguration_CoordinatorDpuSize.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize != null)
            {
                request.EngineConfiguration.CoordinatorDpuSize = requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize.Value;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize = null;
            if (cmdletContext.EngineConfiguration_DefaultExecutorDpuSize != null)
            {
                requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize = cmdletContext.EngineConfiguration_DefaultExecutorDpuSize.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize != null)
            {
                request.EngineConfiguration.DefaultExecutorDpuSize = requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize.Value;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus = null;
            if (cmdletContext.EngineConfiguration_MaxConcurrentDpus != null)
            {
                requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus = cmdletContext.EngineConfiguration_MaxConcurrentDpus.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus != null)
            {
                request.EngineConfiguration.MaxConcurrentDpus = requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus.Value;
                requestEngineConfigurationIsNull = false;
            }
             // determine if request.EngineConfiguration should be set to null
            if (requestEngineConfigurationIsNull)
            {
                request.EngineConfiguration = null;
            }
            if (cmdletContext.NotebookVersion != null)
            {
                request.NotebookVersion = cmdletContext.NotebookVersion;
            }
            if (cmdletContext.SessionIdleTimeoutInMinute != null)
            {
                request.SessionIdleTimeoutInMinutes = cmdletContext.SessionIdleTimeoutInMinute.Value;
            }
            if (cmdletContext.WorkGroup != null)
            {
                request.WorkGroup = cmdletContext.WorkGroup;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Athena.Model.StartSessionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StartSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StartSession");
            try
            {
                #if DESKTOP
                return client.StartSession(request);
                #elif CORECLR
                return client.StartSessionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EngineConfiguration_AdditionalConfig { get; set; }
            public System.Int32? EngineConfiguration_CoordinatorDpuSize { get; set; }
            public System.Int32? EngineConfiguration_DefaultExecutorDpuSize { get; set; }
            public System.Int32? EngineConfiguration_MaxConcurrentDpus { get; set; }
            public System.String NotebookVersion { get; set; }
            public System.Int32? SessionIdleTimeoutInMinute { get; set; }
            public System.String WorkGroup { get; set; }
            public System.Func<Amazon.Athena.Model.StartSessionResponse, StartATHSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
