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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enables <i>block public access for AMIs</i> at the account level in the specified
    /// Amazon Web Services Region. This prevents the public sharing of your AMIs. However,
    /// if you already have public AMIs, they will remain publicly available.
    /// 
    ///  
    /// <para>
    /// The API can take up to 10 minutes to configure this setting. During this time, if
    /// you run <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetImageBlockPublicAccessState.html">GetImageBlockPublicAccessState</a>,
    /// the response will be <c>unblocked</c>. When the API has completed the configuration,
    /// the response will be <c>block-new-sharing</c>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/sharingamis-intro.html#block-public-access-to-amis">Block
    /// public access to your AMIs</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2ImageBlockPublicAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.ImageBlockPublicAccessEnabledState")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableImageBlockPublicAccess API operation.", Operation = new[] {"EnableImageBlockPublicAccess"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableImageBlockPublicAccessResponse))]
    [AWSCmdletOutput("Amazon.EC2.ImageBlockPublicAccessEnabledState or Amazon.EC2.Model.EnableImageBlockPublicAccessResponse",
        "This cmdlet returns an Amazon.EC2.ImageBlockPublicAccessEnabledState object.",
        "The service call response (type Amazon.EC2.Model.EnableImageBlockPublicAccessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2ImageBlockPublicAccessCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImageBlockPublicAccessState
        /// <summary>
        /// <para>
        /// <para>Specify <c>block-new-sharing</c> to enable block public access for AMIs at the account
        /// level in the specified Region. This will block any attempt to publicly share your
        /// AMIs in the specified Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.ImageBlockPublicAccessEnabledState")]
        public Amazon.EC2.ImageBlockPublicAccessEnabledState ImageBlockPublicAccessState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageBlockPublicAccessState'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableImageBlockPublicAccessResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableImageBlockPublicAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageBlockPublicAccessState";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageBlockPublicAccessState), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2ImageBlockPublicAccess (EnableImageBlockPublicAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableImageBlockPublicAccessResponse, EnableEC2ImageBlockPublicAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImageBlockPublicAccessState = this.ImageBlockPublicAccessState;
            #if MODULAR
            if (this.ImageBlockPublicAccessState == null && ParameterWasBound(nameof(this.ImageBlockPublicAccessState)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageBlockPublicAccessState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.EnableImageBlockPublicAccessRequest();
            
            if (cmdletContext.ImageBlockPublicAccessState != null)
            {
                request.ImageBlockPublicAccessState = cmdletContext.ImageBlockPublicAccessState;
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
        
        private Amazon.EC2.Model.EnableImageBlockPublicAccessResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableImageBlockPublicAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableImageBlockPublicAccess");
            try
            {
                #if DESKTOP
                return client.EnableImageBlockPublicAccess(request);
                #elif CORECLR
                return client.EnableImageBlockPublicAccessAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.ImageBlockPublicAccessEnabledState ImageBlockPublicAccessState { get; set; }
            public System.Func<Amazon.EC2.Model.EnableImageBlockPublicAccessResponse, EnableEC2ImageBlockPublicAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageBlockPublicAccessState;
        }
        
    }
}
