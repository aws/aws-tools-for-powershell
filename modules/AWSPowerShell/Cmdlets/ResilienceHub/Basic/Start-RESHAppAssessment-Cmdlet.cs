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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Creates a new application assessment for an application.
    /// </summary>
    [Cmdlet("Start", "RESHAppAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResilienceHub.Model.AppAssessment")]
    [AWSCmdlet("Calls the AWS Resilience Hub StartAppAssessment API operation.", Operation = new[] {"StartAppAssessment"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.StartAppAssessmentResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.AppAssessment or Amazon.ResilienceHub.Model.StartAppAssessmentResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.AppAssessment object.",
        "The service call response (type Amazon.ResilienceHub.Model.StartAppAssessmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartRESHAppAssessmentCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<c>partition</c>:resiliencehub:<c>region</c>:<c>account</c>:app/<c>app-id</c>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
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
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter AppVersion
        /// <summary>
        /// <para>
        /// <para>The version of the application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppVersion { get; set; }
        #endregion
        
        #region Parameter AssessmentName
        /// <summary>
        /// <para>
        /// <para>The name for the assessment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AssessmentName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to the resource. A tag is a label that you assign to an Amazon Web Services
        /// resource. Each tag consists of a key/value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for an idempotency token. A client token is a unique, case-sensitive string of
        /// up to 64 ASCII characters. You should not reuse the same client token for other API
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Assessment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.StartAppAssessmentResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.StartAppAssessmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Assessment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RESHAppAssessment (StartAppAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.StartAppAssessmentResponse, StartRESHAppAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppArn = this.AppArn;
            #if MODULAR
            if (this.AppArn == null && ParameterWasBound(nameof(this.AppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppVersion = this.AppVersion;
            #if MODULAR
            if (this.AppVersion == null && ParameterWasBound(nameof(this.AppVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AppVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssessmentName = this.AssessmentName;
            #if MODULAR
            if (this.AssessmentName == null && ParameterWasBound(nameof(this.AssessmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.ResilienceHub.Model.StartAppAssessmentRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.AppVersion != null)
            {
                request.AppVersion = cmdletContext.AppVersion;
            }
            if (cmdletContext.AssessmentName != null)
            {
                request.AssessmentName = cmdletContext.AssessmentName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ResilienceHub.Model.StartAppAssessmentResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.StartAppAssessmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "StartAppAssessment");
            try
            {
                #if DESKTOP
                return client.StartAppAssessment(request);
                #elif CORECLR
                return client.StartAppAssessmentAsync(request).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public System.String AppVersion { get; set; }
            public System.String AssessmentName { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.StartAppAssessmentResponse, StartRESHAppAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Assessment;
        }
        
    }
}
