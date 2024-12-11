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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the traffic distribution for a given traffic distribution group. 
    /// 
    ///  <note><para>
    /// The <c>SignInConfig</c> distribution is available only on a default <c>TrafficDistributionGroup</c>
    /// (see the <c>IsDefault</c> parameter in the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_TrafficDistributionGroup.html">TrafficDistributionGroup</a>
    /// data type). If you call <c>UpdateTrafficDistribution</c> with a modified <c>SignInConfig</c>
    /// and a non-default <c>TrafficDistributionGroup</c>, an <c>InvalidRequestException</c>
    /// is returned.
    /// </para></note><para>
    /// For more information about updating a traffic distribution group, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/update-telephony-traffic-distribution.html">Update
    /// telephony traffic distribution across Amazon Web Services Regions </a> in the <i>Amazon
    /// Connect Administrator Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNTrafficDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateTrafficDistribution API operation.", Operation = new[] {"UpdateTrafficDistribution"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateTrafficDistributionResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateTrafficDistributionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateTrafficDistributionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNTrafficDistributionCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentConfig_Distribution
        /// <summary>
        /// <para>
        /// <para>Information about traffic distributions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentConfig_Distributions")]
        public Amazon.Connect.Model.Distribution[] AgentConfig_Distribution { get; set; }
        #endregion
        
        #region Parameter SignInConfig_Distribution
        /// <summary>
        /// <para>
        /// <para>Information about traffic distributions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SignInConfig_Distributions")]
        public Amazon.Connect.Model.SignInDistribution[] SignInConfig_Distribution { get; set; }
        #endregion
        
        #region Parameter TelephonyConfig_Distribution
        /// <summary>
        /// <para>
        /// <para>Information about traffic distributions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TelephonyConfig_Distributions")]
        public Amazon.Connect.Model.Distribution[] TelephonyConfig_Distribution { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the traffic distribution group. This can be the ID or the ARN if
        /// the API is being called in the Region where the traffic distribution group was created.
        /// The ARN must be provided if the call is from the replicated Region. </para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateTrafficDistributionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNTrafficDistribution (UpdateTrafficDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateTrafficDistributionResponse, UpdateCONNTrafficDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentConfig_Distribution != null)
            {
                context.AgentConfig_Distribution = new List<Amazon.Connect.Model.Distribution>(this.AgentConfig_Distribution);
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SignInConfig_Distribution != null)
            {
                context.SignInConfig_Distribution = new List<Amazon.Connect.Model.SignInDistribution>(this.SignInConfig_Distribution);
            }
            if (this.TelephonyConfig_Distribution != null)
            {
                context.TelephonyConfig_Distribution = new List<Amazon.Connect.Model.Distribution>(this.TelephonyConfig_Distribution);
            }
            
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
            var request = new Amazon.Connect.Model.UpdateTrafficDistributionRequest();
            
            
             // populate AgentConfig
            var requestAgentConfigIsNull = true;
            request.AgentConfig = new Amazon.Connect.Model.AgentConfig();
            List<Amazon.Connect.Model.Distribution> requestAgentConfig_agentConfig_Distribution = null;
            if (cmdletContext.AgentConfig_Distribution != null)
            {
                requestAgentConfig_agentConfig_Distribution = cmdletContext.AgentConfig_Distribution;
            }
            if (requestAgentConfig_agentConfig_Distribution != null)
            {
                request.AgentConfig.Distributions = requestAgentConfig_agentConfig_Distribution;
                requestAgentConfigIsNull = false;
            }
             // determine if request.AgentConfig should be set to null
            if (requestAgentConfigIsNull)
            {
                request.AgentConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate SignInConfig
            var requestSignInConfigIsNull = true;
            request.SignInConfig = new Amazon.Connect.Model.SignInConfig();
            List<Amazon.Connect.Model.SignInDistribution> requestSignInConfig_signInConfig_Distribution = null;
            if (cmdletContext.SignInConfig_Distribution != null)
            {
                requestSignInConfig_signInConfig_Distribution = cmdletContext.SignInConfig_Distribution;
            }
            if (requestSignInConfig_signInConfig_Distribution != null)
            {
                request.SignInConfig.Distributions = requestSignInConfig_signInConfig_Distribution;
                requestSignInConfigIsNull = false;
            }
             // determine if request.SignInConfig should be set to null
            if (requestSignInConfigIsNull)
            {
                request.SignInConfig = null;
            }
            
             // populate TelephonyConfig
            var requestTelephonyConfigIsNull = true;
            request.TelephonyConfig = new Amazon.Connect.Model.TelephonyConfig();
            List<Amazon.Connect.Model.Distribution> requestTelephonyConfig_telephonyConfig_Distribution = null;
            if (cmdletContext.TelephonyConfig_Distribution != null)
            {
                requestTelephonyConfig_telephonyConfig_Distribution = cmdletContext.TelephonyConfig_Distribution;
            }
            if (requestTelephonyConfig_telephonyConfig_Distribution != null)
            {
                request.TelephonyConfig.Distributions = requestTelephonyConfig_telephonyConfig_Distribution;
                requestTelephonyConfigIsNull = false;
            }
             // determine if request.TelephonyConfig should be set to null
            if (requestTelephonyConfigIsNull)
            {
                request.TelephonyConfig = null;
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
        
        private Amazon.Connect.Model.UpdateTrafficDistributionResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateTrafficDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateTrafficDistribution");
            try
            {
                #if DESKTOP
                return client.UpdateTrafficDistribution(request);
                #elif CORECLR
                return client.UpdateTrafficDistributionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.Distribution> AgentConfig_Distribution { get; set; }
            public System.String Id { get; set; }
            public List<Amazon.Connect.Model.SignInDistribution> SignInConfig_Distribution { get; set; }
            public List<Amazon.Connect.Model.Distribution> TelephonyConfig_Distribution { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateTrafficDistributionResponse, UpdateCONNTrafficDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
