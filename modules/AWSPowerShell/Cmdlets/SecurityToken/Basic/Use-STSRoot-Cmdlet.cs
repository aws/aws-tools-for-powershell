/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a set of short term credentials you can use to perform privileged tasks on
    /// a member account in your organization.
    /// 
    ///  
    /// <para>
    /// Before you can launch a privileged session, you must have centralized root access
    /// in your organization. For steps to enable this feature, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_root-enable-root-access.html">Centralize
    /// root access for member accounts</a> in the <i>IAM User Guide</i>.
    /// </para><note><para>
    /// The STS global endpoint is not supported for AssumeRoot. You must send this request
    /// to a Regional STS endpoint. For more information, see <a href="https://docs.aws.amazon.com/STS/latest/APIReference/welcome.html#sts-endpoints">Endpoints</a>.
    /// </para></note><para>
    /// You can track AssumeRoot in CloudTrail logs to determine what actions were performed
    /// in a session. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/cloudtrail-track-privileged-tasks.html">Track
    /// privileged tasks in CloudTrail</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Use", "STSRoot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityToken.Model.AssumeRootResponse")]
    [AWSCmdlet("Calls the AWS Security Token Service (STS) AssumeRoot API operation.", Operation = new[] {"AssumeRoot"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.AssumeRootResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.AssumeRootResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.AssumeRootResponse object containing multiple properties."
    )]
    public partial class UseSTSRootCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TaskPolicyArn_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM managed policy to use as a session policy
        /// for the role. For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon
        /// Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskPolicyArn_Arn { get; set; }
        #endregion
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the privileged session. The value can range from 0 seconds
        /// up to the maximum session duration of 900 seconds (15 minutes). If you specify a value
        /// higher than this setting, the operation fails.</para><para>By default, the value is set to <c>900</c> seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter TargetPrincipal
        /// <summary>
        /// <para>
        /// <para>The member account principal ARN or account ID.</para>
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
        public System.String TargetPrincipal { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.AssumeRootResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.AssumeRootResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetPrincipal parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetPrincipal' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetPrincipal' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskPolicyArn_Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Use-STSRoot (AssumeRoot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.AssumeRootResponse, UseSTSRootCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetPrincipal;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DurationInSeconds = this.DurationInSeconds;
            context.TargetPrincipal = this.TargetPrincipal;
            #if MODULAR
            if (this.TargetPrincipal == null && ParameterWasBound(nameof(this.TargetPrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetPrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskPolicyArn_Arn = this.TaskPolicyArn_Arn;
            
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
            var request = new Amazon.SecurityToken.Model.AssumeRootRequest();
            
            if (cmdletContext.DurationInSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationInSeconds.Value;
            }
            if (cmdletContext.TargetPrincipal != null)
            {
                request.TargetPrincipal = cmdletContext.TargetPrincipal;
            }
            
             // populate TaskPolicyArn
            var requestTaskPolicyArnIsNull = true;
            request.TaskPolicyArn = new Amazon.SecurityToken.Model.PolicyDescriptorType();
            System.String requestTaskPolicyArn_taskPolicyArn_Arn = null;
            if (cmdletContext.TaskPolicyArn_Arn != null)
            {
                requestTaskPolicyArn_taskPolicyArn_Arn = cmdletContext.TaskPolicyArn_Arn;
            }
            if (requestTaskPolicyArn_taskPolicyArn_Arn != null)
            {
                request.TaskPolicyArn.Arn = requestTaskPolicyArn_taskPolicyArn_Arn;
                requestTaskPolicyArnIsNull = false;
            }
             // determine if request.TaskPolicyArn should be set to null
            if (requestTaskPolicyArnIsNull)
            {
                request.TaskPolicyArn = null;
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
        
        private Amazon.SecurityToken.Model.AssumeRootResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.AssumeRootRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service (STS)", "AssumeRoot");
            try
            {
                #if DESKTOP
                return client.AssumeRoot(request);
                #elif CORECLR
                return client.AssumeRootAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationInSeconds { get; set; }
            public System.String TargetPrincipal { get; set; }
            public System.String TaskPolicyArn_Arn { get; set; }
            public System.Func<Amazon.SecurityToken.Model.AssumeRootResponse, UseSTSRootCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
