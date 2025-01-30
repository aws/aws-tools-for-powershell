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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Finds the default parameters for a specific self-service action on a specific provisioned
    /// product and returns a map of the results to the user.
    /// </summary>
    [Cmdlet("Get", "SCServiceActionExecutionParameter")]
    [OutputType("Amazon.ServiceCatalog.Model.ExecutionParameter")]
    [AWSCmdlet("Calls the AWS Service Catalog DescribeServiceActionExecutionParameters API operation.", Operation = new[] {"DescribeServiceActionExecutionParameters"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.ExecutionParameter or Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse",
        "This cmdlet returns a collection of Amazon.ServiceCatalog.Model.ExecutionParameter objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSCServiceActionExecutionParameterCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioned product.</para>
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
        public System.String ProvisionedProductId { get; set; }
        #endregion
        
        #region Parameter ServiceActionId
        /// <summary>
        /// <para>
        /// <para>The self-service action identifier.</para>
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
        public System.String ServiceActionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceActionParameters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceActionParameters";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceActionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceActionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceActionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse, GetSCServiceActionExecutionParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceActionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            context.ProvisionedProductId = this.ProvisionedProductId;
            #if MODULAR
            if (this.ProvisionedProductId == null && ParameterWasBound(nameof(this.ProvisionedProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceActionId = this.ServiceActionId;
            #if MODULAR
            if (this.ServiceActionId == null && ParameterWasBound(nameof(this.ServiceActionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceActionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.ProvisionedProductId != null)
            {
                request.ProvisionedProductId = cmdletContext.ProvisionedProductId;
            }
            if (cmdletContext.ServiceActionId != null)
            {
                request.ServiceActionId = cmdletContext.ServiceActionId;
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
        
        private Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "DescribeServiceActionExecutionParameters");
            try
            {
                #if DESKTOP
                return client.DescribeServiceActionExecutionParameters(request);
                #elif CORECLR
                return client.DescribeServiceActionExecutionParametersAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String ProvisionedProductId { get; set; }
            public System.String ServiceActionId { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.DescribeServiceActionExecutionParametersResponse, GetSCServiceActionExecutionParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceActionParameters;
        }
        
    }
}
