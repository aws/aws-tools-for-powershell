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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Enables <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-multi-region-replication.html">Multi-Region
    /// key replication</a> settings for your Amazon Web Services account, causing new keys
    /// to be automatically replicated to the specified Amazon Web Services Regions when created.
    /// 
    ///  
    /// <para>
    /// When Multi-Region key replication are enabled, any new keys created in your account
    /// will automatically be replicated to these regions unless you explicitly override this
    /// behavior during key creation. This simplifies key management for applications that
    /// operate across multiple regions.
    /// </para><para>
    /// Existing keys are not affected by this operation - only keys created after enabling
    /// default replication will be automatically replicated.
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_DisableDefaultKeyReplicationRegions.html">DisableDefaultKeyReplicationRegions</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetDefaultKeyReplicationRegions.html">GetDefaultKeyReplicationRegions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Enable", "PAYCCDefaultKeyReplicationRegion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane EnableDefaultKeyReplicationRegions API operation.", Operation = new[] {"EnableDefaultKeyReplicationRegions"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnablePAYCCDefaultKeyReplicationRegionCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReplicationRegion
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services Regions to enable as default replication regions for
        /// the Amazon Web Services account for <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-multi-region-replication.html">Multi-Region
        /// key replication</a>.</para><para>New keys created in this account will automatically be replicated to these regions
        /// unless explicitly overridden during key creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ReplicationRegions")]
        public System.String[] ReplicationRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnabledReplicationRegions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnabledReplicationRegions";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationRegion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-PAYCCDefaultKeyReplicationRegion (EnableDefaultKeyReplicationRegions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse, EnablePAYCCDefaultKeyReplicationRegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ReplicationRegion != null)
            {
                context.ReplicationRegion = new List<System.String>(this.ReplicationRegion);
            }
            #if MODULAR
            if (this.ReplicationRegion == null && ParameterWasBound(nameof(this.ReplicationRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsRequest();
            
            if (cmdletContext.ReplicationRegion != null)
            {
                request.ReplicationRegions = cmdletContext.ReplicationRegion;
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
        
        private Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "EnableDefaultKeyReplicationRegions");
            try
            {
                #if DESKTOP
                return client.EnableDefaultKeyReplicationRegions(request);
                #elif CORECLR
                return client.EnableDefaultKeyReplicationRegionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ReplicationRegion { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.EnableDefaultKeyReplicationRegionsResponse, EnablePAYCCDefaultKeyReplicationRegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnabledReplicationRegions;
        }
        
    }
}
