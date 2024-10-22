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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Updates the bundle of your Amazon Lightsail content delivery network (CDN) distribution.
    /// 
    ///  
    /// <para>
    /// A distribution bundle specifies the monthly network transfer quota and monthly cost
    /// of your distribution.
    /// </para><para>
    /// Update your distribution's bundle if your distribution is going over its monthly network
    /// transfer quota and is incurring an overage fee.
    /// </para><para>
    /// You can update your distribution's bundle only one time within your monthly Amazon
    /// Web Services billing cycle. To determine if you can update your distribution's bundle,
    /// use the <c>GetDistributions</c> action. The <c>ableToUpdateBundle</c> parameter in
    /// the result will indicate whether you can currently update your distribution's bundle.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSDistributionBundle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateDistributionBundle API operation.", Operation = new[] {"UpdateDistributionBundle"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateDistributionBundleResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.UpdateDistributionBundleResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.UpdateDistributionBundleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLSDistributionBundleCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle ID of the new bundle to apply to your distribution.</para><para>Use the <c>GetDistributionBundles</c> action to get a list of distribution bundle
        /// IDs that you can specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter DistributionName
        /// <summary>
        /// <para>
        /// <para>The name of the distribution for which to update the bundle.</para><para>Use the <c>GetDistributions</c> action to get a list of distribution names that you
        /// can specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DistributionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateDistributionBundleResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateDistributionBundleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSDistributionBundle (UpdateDistributionBundle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateDistributionBundleResponse, UpdateLSDistributionBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BundleId = this.BundleId;
            context.DistributionName = this.DistributionName;
            
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
            var request = new Amazon.Lightsail.Model.UpdateDistributionBundleRequest();
            
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            if (cmdletContext.DistributionName != null)
            {
                request.DistributionName = cmdletContext.DistributionName;
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
        
        private Amazon.Lightsail.Model.UpdateDistributionBundleResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateDistributionBundleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateDistributionBundle");
            try
            {
                #if DESKTOP
                return client.UpdateDistributionBundle(request);
                #elif CORECLR
                return client.UpdateDistributionBundleAsync(request).GetAwaiter().GetResult();
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
            public System.String BundleId { get; set; }
            public System.String DistributionName { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateDistributionBundleResponse, UpdateLSDistributionBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
