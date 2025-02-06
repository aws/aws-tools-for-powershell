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
    /// Disables EBS encryption by default for your account in the current Region.
    /// 
    ///  
    /// <para>
    /// After you disable encryption by default, you can still create encrypted volumes by
    /// enabling encryption when you create each volume.
    /// </para><para>
    /// Disabling encryption by default does not change the encryption status of your existing
    /// volumes.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption.html">Amazon
    /// EBS encryption</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "EC2EbsEncryptionByDefault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisableEbsEncryptionByDefault API operation.", Operation = new[] {"DisableEbsEncryptionByDefault"}, SelectReturnType = typeof(Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse) can be returned by specifying '-Select *'."
    )]
    public partial class DisableEC2EbsEncryptionByDefaultCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EbsEncryptionByDefault'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EbsEncryptionByDefault";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-EC2EbsEncryptionByDefault (DisableEbsEncryptionByDefault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse, DisableEC2EbsEncryptionByDefaultCmdlet>(Select) ??
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
            var request = new Amazon.EC2.Model.DisableEbsEncryptionByDefaultRequest();
            
            
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
        
        private Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisableEbsEncryptionByDefaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisableEbsEncryptionByDefault");
            try
            {
                #if DESKTOP
                return client.DisableEbsEncryptionByDefault(request);
                #elif CORECLR
                return client.DisableEbsEncryptionByDefaultAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.DisableEbsEncryptionByDefaultResponse, DisableEC2EbsEncryptionByDefaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EbsEncryptionByDefault;
        }
        
    }
}
