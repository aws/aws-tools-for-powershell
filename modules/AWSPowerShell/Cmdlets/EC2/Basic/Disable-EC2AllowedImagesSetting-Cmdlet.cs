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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Disables Allowed AMIs for your account in the specified Amazon Web Services Region.
    /// When set to <c>disabled</c>, the image criteria in your Allowed AMIs settings do not
    /// apply, and no restrictions are placed on AMI discoverability or usage. Users in your
    /// account can launch instances using any public AMI or AMI shared with your account.
    /// 
    ///  <note><para>
    /// The Allowed AMIs feature does not restrict the AMIs owned by your account. Regardless
    /// of the criteria you set, the AMIs created by your account will always be discoverable
    /// and usable by users in your account.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-allowed-amis.html">Control
    /// the discovery and use of AMIs in Amazon EC2 with Allowed AMIs</a> in <i>Amazon EC2
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "EC2AllowedImagesSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.AllowedImagesSettingsDisabledState")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisableAllowedImagesSettings API operation.", Operation = new[] {"DisableAllowedImagesSettings"}, SelectReturnType = typeof(Amazon.EC2.Model.DisableAllowedImagesSettingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.AllowedImagesSettingsDisabledState or Amazon.EC2.Model.DisableAllowedImagesSettingsResponse",
        "This cmdlet returns an Amazon.EC2.AllowedImagesSettingsDisabledState object.",
        "The service call response (type Amazon.EC2.Model.DisableAllowedImagesSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class DisableEC2AllowedImagesSettingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AllowedImagesSettingsState'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisableAllowedImagesSettingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisableAllowedImagesSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AllowedImagesSettingsState";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-EC2AllowedImagesSetting (DisableAllowedImagesSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisableAllowedImagesSettingsResponse, DisableEC2AllowedImagesSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.EC2.Model.DisableAllowedImagesSettingsRequest();
            
            
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
        
        private Amazon.EC2.Model.DisableAllowedImagesSettingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisableAllowedImagesSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisableAllowedImagesSettings");
            try
            {
                return client.DisableAllowedImagesSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.DisableAllowedImagesSettingsResponse, DisableEC2AllowedImagesSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AllowedImagesSettingsState;
        }
        
    }
}
