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
using Amazon.MarketplaceDeployment;
using Amazon.MarketplaceDeployment.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MD
{
    /// <summary>
    /// Returns the active deployment configuration for a product and delivery option. The
    /// active deployment configuration is the configuration from the most recent successful
    /// deployment configuration job. The seller that owns the product and buyers entitled
    /// to the product can call this operation.
    /// 
    ///  
    /// <para>
    /// If the product and delivery option have no active deployment configuration, the operation
    /// returns a <c>ResourceNotFoundException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "MDDeploymentConfiguration")]
    [OutputType("Amazon.MarketplaceDeployment.Model.DeploymentConfigurationDetail")]
    [AWSCmdlet("Calls the AWS Marketplace Deployment Service GetDeploymentConfiguration API operation.", Operation = new[] {"GetDeploymentConfiguration"}, SelectReturnType = typeof(Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceDeployment.Model.DeploymentConfigurationDetail or Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse",
        "This cmdlet returns an Amazon.MarketplaceDeployment.Model.DeploymentConfigurationDetail object.",
        "The service call response (type Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMDDeploymentConfigurationCmdlet : AmazonMarketplaceDeploymentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog related to the request. Fixed value: <c>AWSMarketplace</c></para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter DeliveryOptionType
        /// <summary>
        /// <para>
        /// <para>The delivery option type of the deployment configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MarketplaceDeployment.DeliveryOptionType")]
        public Amazon.MarketplaceDeployment.DeliveryOptionType DeliveryOptionType { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Marketplace product, for example <c>prod-1234567890abc</c>.</para>
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
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse, GetMDDeploymentConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryOptionType = this.DeliveryOptionType;
            #if MODULAR
            if (this.DeliveryOptionType == null && ParameterWasBound(nameof(this.DeliveryOptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryOptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.DeliveryOptionType != null)
            {
                request.DeliveryOptionType = cmdletContext.DeliveryOptionType;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
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
        
        private Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse CallAWSServiceOperation(IAmazonMarketplaceDeployment client, Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Deployment Service", "GetDeploymentConfiguration");
            try
            {
                return client.GetDeploymentConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public Amazon.MarketplaceDeployment.DeliveryOptionType DeliveryOptionType { get; set; }
            public System.String ProductId { get; set; }
            public System.Func<Amazon.MarketplaceDeployment.Model.GetDeploymentConfigurationResponse, GetMDDeploymentConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
