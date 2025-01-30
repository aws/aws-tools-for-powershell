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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Discontinue Windows fast launch for a Windows AMI, and clean up existing pre-provisioned
    /// snapshots. After you disable Windows fast launch, the AMI uses the standard launch
    /// process for each new instance. Amazon EC2 must remove all pre-provisioned snapshots
    /// before you can enable Windows fast launch again.
    /// 
    ///  <note><para>
    /// You can only change these settings for Windows AMIs that you own or that have been
    /// shared with you.
    /// </para></note>
    /// </summary>
    [Cmdlet("Disable", "EC2FastLaunch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DisableFastLaunchResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisableFastLaunch API operation.", Operation = new[] {"DisableFastLaunch"}, SelectReturnType = typeof(Amazon.EC2.Model.DisableFastLaunchResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DisableFastLaunchResponse",
        "This cmdlet returns an Amazon.EC2.Model.DisableFastLaunchResponse object containing multiple properties."
    )]
    public partial class DisableEC2FastLaunchCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ForceStop
        /// <summary>
        /// <para>
        /// <para>Forces the image settings to turn off Windows fast launch for your Windows AMI. This
        /// parameter overrides any errors that are encountered while cleaning up resources in
        /// your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceStop { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>Specify the ID of the image for which to disable Windows fast launch.</para>
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
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisableFastLaunchResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisableFastLaunchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-EC2FastLaunch (DisableFastLaunch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisableFastLaunchResponse, DisableEC2FastLaunchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ForceStop = this.ForceStop;
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DisableFastLaunchRequest();
            
            if (cmdletContext.ForceStop != null)
            {
                request.Force = cmdletContext.ForceStop.Value;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
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
        
        private Amazon.EC2.Model.DisableFastLaunchResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisableFastLaunchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisableFastLaunch");
            try
            {
                #if DESKTOP
                return client.DisableFastLaunch(request);
                #elif CORECLR
                return client.DisableFastLaunchAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ForceStop { get; set; }
            public System.String ImageId { get; set; }
            public System.Func<Amazon.EC2.Model.DisableFastLaunchResponse, DisableEC2FastLaunchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
