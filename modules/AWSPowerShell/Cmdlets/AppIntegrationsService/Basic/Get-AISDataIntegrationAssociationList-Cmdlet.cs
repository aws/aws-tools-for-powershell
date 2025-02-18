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
using Amazon.AppIntegrationsService;
using Amazon.AppIntegrationsService.Model;

namespace Amazon.PowerShell.Cmdlets.AIS
{
    /// <summary>
    /// Returns a paginated list of DataIntegration associations in the account.
    /// 
    ///  <note><para>
    /// You cannot create a DataIntegration association for a DataIntegration that has been
    /// previously associated. Use a different DataIntegration, or recreate the DataIntegration
    /// using the <a href="https://docs.aws.amazon.com/appintegrations/latest/APIReference/API_CreateDataIntegration.html">CreateDataIntegration</a>
    /// API.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "AISDataIntegrationAssociationList")]
    [OutputType("Amazon.AppIntegrationsService.Model.DataIntegrationAssociationSummary")]
    [AWSCmdlet("Calls the Amazon AppIntegrations Service ListDataIntegrationAssociations API operation.", Operation = new[] {"ListDataIntegrationAssociations"}, SelectReturnType = typeof(Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse))]
    [AWSCmdletOutput("Amazon.AppIntegrationsService.Model.DataIntegrationAssociationSummary or Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse",
        "This cmdlet returns a collection of Amazon.AppIntegrationsService.Model.DataIntegrationAssociationSummary objects.",
        "The service call response (type Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAISDataIntegrationAssociationListCmdlet : AmazonAppIntegrationsServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataIntegrationIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the DataIntegration.</para>
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
        public System.String DataIntegrationIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataIntegrationAssociations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse).
        /// Specifying the name of a property of type Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataIntegrationAssociations";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse, GetAISDataIntegrationAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataIntegrationIdentifier = this.DataIntegrationIdentifier;
            #if MODULAR
            if (this.DataIntegrationIdentifier == null && ParameterWasBound(nameof(this.DataIntegrationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataIntegrationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsRequest();
            
            if (cmdletContext.DataIntegrationIdentifier != null)
            {
                request.DataIntegrationIdentifier = cmdletContext.DataIntegrationIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse CallAWSServiceOperation(IAmazonAppIntegrationsService client, Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppIntegrations Service", "ListDataIntegrationAssociations");
            try
            {
                return client.ListDataIntegrationAssociationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataIntegrationIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AppIntegrationsService.Model.ListDataIntegrationAssociationsResponse, GetAISDataIntegrationAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataIntegrationAssociations;
        }
        
    }
}
