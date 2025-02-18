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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Starts a CloudTrail Lake query. Use the <c>QueryStatement</c> parameter to provide
    /// your SQL query, enclosed in single quotation marks. Use the optional <c>DeliveryS3Uri</c>
    /// parameter to deliver the query results to an S3 bucket.
    /// 
    ///  
    /// <para><c>StartQuery</c> requires you specify either the <c>QueryStatement</c> parameter,
    /// or a <c>QueryAlias</c> and any <c>QueryParameters</c>. In the current release, the
    /// <c>QueryAlias</c> and <c>QueryParameters</c> parameters are used only for the queries
    /// that populate the CloudTrail Lake dashboards.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CTQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudTrail StartQuery API operation.", Operation = new[] {"StartQuery"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.StartQueryResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudTrail.Model.StartQueryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudTrail.Model.StartQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCTQueryCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliveryS3Uri
        /// <summary>
        /// <para>
        /// <para> The URI for the S3 bucket where CloudTrail delivers the query results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryS3Uri { get; set; }
        #endregion
        
        #region Parameter EventDataStoreOwnerAccountId
        /// <summary>
        /// <para>
        /// <para> The account ID of the event data store owner. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventDataStoreOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter QueryAlias
        /// <summary>
        /// <para>
        /// <para> The alias that identifies a query template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryAlias { get; set; }
        #endregion
        
        #region Parameter QueryParameter
        /// <summary>
        /// <para>
        /// <para> The query parameters for the specified <c>QueryAlias</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryParameters")]
        public System.String[] QueryParameter { get; set; }
        #endregion
        
        #region Parameter QueryStatement
        /// <summary>
        /// <para>
        /// <para>The SQL code of your query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueryStatement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.StartQueryResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.StartQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueryStatement), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CTQuery (StartQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.StartQueryResponse, StartCTQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryS3Uri = this.DeliveryS3Uri;
            context.EventDataStoreOwnerAccountId = this.EventDataStoreOwnerAccountId;
            context.QueryAlias = this.QueryAlias;
            if (this.QueryParameter != null)
            {
                context.QueryParameter = new List<System.String>(this.QueryParameter);
            }
            context.QueryStatement = this.QueryStatement;
            
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
            var request = new Amazon.CloudTrail.Model.StartQueryRequest();
            
            if (cmdletContext.DeliveryS3Uri != null)
            {
                request.DeliveryS3Uri = cmdletContext.DeliveryS3Uri;
            }
            if (cmdletContext.EventDataStoreOwnerAccountId != null)
            {
                request.EventDataStoreOwnerAccountId = cmdletContext.EventDataStoreOwnerAccountId;
            }
            if (cmdletContext.QueryAlias != null)
            {
                request.QueryAlias = cmdletContext.QueryAlias;
            }
            if (cmdletContext.QueryParameter != null)
            {
                request.QueryParameters = cmdletContext.QueryParameter;
            }
            if (cmdletContext.QueryStatement != null)
            {
                request.QueryStatement = cmdletContext.QueryStatement;
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
        
        private Amazon.CloudTrail.Model.StartQueryResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.StartQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "StartQuery");
            try
            {
                return client.StartQueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeliveryS3Uri { get; set; }
            public System.String EventDataStoreOwnerAccountId { get; set; }
            public System.String QueryAlias { get; set; }
            public List<System.String> QueryParameter { get; set; }
            public System.String QueryStatement { get; set; }
            public System.Func<Amazon.CloudTrail.Model.StartQueryResponse, StartCTQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryId;
        }
        
    }
}
