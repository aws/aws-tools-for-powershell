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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Saves a new query or updates an existing saved query. The <c>QueryName</c> must be
    /// unique for a single Amazon Web Services account and a single Amazon Web Services Region.
    /// You can create upto 300 queries in a single Amazon Web Services account and a single
    /// Amazon Web Services Region.
    /// 
    ///  <note><para><b>Tags are added at creation and cannot be updated</b></para><para><c>PutStoredQuery</c> is an idempotent API. Subsequent requests won’t create a duplicate
    /// resource if one was already created. If a following request has different <c>tags</c>
    /// values, Config will ignore these differences and treat it as an idempotent request
    /// of the previous. In this case, <c>tags</c> will not be updated, even if they are different.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGStoredQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config PutStoredQuery API operation.", Operation = new[] {"PutStoredQuery"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutStoredQueryResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.PutStoredQueryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.PutStoredQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGStoredQueryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StoredQuery_Description
        /// <summary>
        /// <para>
        /// <para>A unique description for the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StoredQuery_Description { get; set; }
        #endregion
        
        #region Parameter StoredQuery_Expression
        /// <summary>
        /// <para>
        /// <para>The expression of the query. For example, <c>SELECT resourceId, resourceType, supplementaryConfiguration.BucketVersioningConfiguration.status
        /// WHERE resourceType = 'AWS::S3::Bucket' AND supplementaryConfiguration.BucketVersioningConfiguration.status
        /// = 'Off'.</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StoredQuery_Expression { get; set; }
        #endregion
        
        #region Parameter StoredQuery_QueryArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the query. For example, arn:partition:service:region:account-id:resource-type/resource-name/resource-id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StoredQuery_QueryArn { get; set; }
        #endregion
        
        #region Parameter StoredQuery_QueryId
        /// <summary>
        /// <para>
        /// <para>The ID of the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StoredQuery_QueryId { get; set; }
        #endregion
        
        #region Parameter StoredQuery_QueryName
        /// <summary>
        /// <para>
        /// <para>The name of the query.</para>
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
        public System.String StoredQuery_QueryName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <c>Tags</c> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutStoredQueryResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutStoredQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StoredQuery_QueryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGStoredQuery (PutStoredQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutStoredQueryResponse, WriteCFGStoredQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StoredQuery_Description = this.StoredQuery_Description;
            context.StoredQuery_Expression = this.StoredQuery_Expression;
            context.StoredQuery_QueryArn = this.StoredQuery_QueryArn;
            context.StoredQuery_QueryId = this.StoredQuery_QueryId;
            context.StoredQuery_QueryName = this.StoredQuery_QueryName;
            #if MODULAR
            if (this.StoredQuery_QueryName == null && ParameterWasBound(nameof(this.StoredQuery_QueryName)))
            {
                WriteWarning("You are passing $null as a value for parameter StoredQuery_QueryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutStoredQueryRequest();
            
            
             // populate StoredQuery
            var requestStoredQueryIsNull = true;
            request.StoredQuery = new Amazon.ConfigService.Model.StoredQuery();
            System.String requestStoredQuery_storedQuery_Description = null;
            if (cmdletContext.StoredQuery_Description != null)
            {
                requestStoredQuery_storedQuery_Description = cmdletContext.StoredQuery_Description;
            }
            if (requestStoredQuery_storedQuery_Description != null)
            {
                request.StoredQuery.Description = requestStoredQuery_storedQuery_Description;
                requestStoredQueryIsNull = false;
            }
            System.String requestStoredQuery_storedQuery_Expression = null;
            if (cmdletContext.StoredQuery_Expression != null)
            {
                requestStoredQuery_storedQuery_Expression = cmdletContext.StoredQuery_Expression;
            }
            if (requestStoredQuery_storedQuery_Expression != null)
            {
                request.StoredQuery.Expression = requestStoredQuery_storedQuery_Expression;
                requestStoredQueryIsNull = false;
            }
            System.String requestStoredQuery_storedQuery_QueryArn = null;
            if (cmdletContext.StoredQuery_QueryArn != null)
            {
                requestStoredQuery_storedQuery_QueryArn = cmdletContext.StoredQuery_QueryArn;
            }
            if (requestStoredQuery_storedQuery_QueryArn != null)
            {
                request.StoredQuery.QueryArn = requestStoredQuery_storedQuery_QueryArn;
                requestStoredQueryIsNull = false;
            }
            System.String requestStoredQuery_storedQuery_QueryId = null;
            if (cmdletContext.StoredQuery_QueryId != null)
            {
                requestStoredQuery_storedQuery_QueryId = cmdletContext.StoredQuery_QueryId;
            }
            if (requestStoredQuery_storedQuery_QueryId != null)
            {
                request.StoredQuery.QueryId = requestStoredQuery_storedQuery_QueryId;
                requestStoredQueryIsNull = false;
            }
            System.String requestStoredQuery_storedQuery_QueryName = null;
            if (cmdletContext.StoredQuery_QueryName != null)
            {
                requestStoredQuery_storedQuery_QueryName = cmdletContext.StoredQuery_QueryName;
            }
            if (requestStoredQuery_storedQuery_QueryName != null)
            {
                request.StoredQuery.QueryName = requestStoredQuery_storedQuery_QueryName;
                requestStoredQueryIsNull = false;
            }
             // determine if request.StoredQuery should be set to null
            if (requestStoredQueryIsNull)
            {
                request.StoredQuery = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ConfigService.Model.PutStoredQueryResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutStoredQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutStoredQuery");
            try
            {
                #if DESKTOP
                return client.PutStoredQuery(request);
                #elif CORECLR
                return client.PutStoredQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String StoredQuery_Description { get; set; }
            public System.String StoredQuery_Expression { get; set; }
            public System.String StoredQuery_QueryArn { get; set; }
            public System.String StoredQuery_QueryId { get; set; }
            public System.String StoredQuery_QueryName { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutStoredQueryResponse, WriteCFGStoredQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryArn;
        }
        
    }
}
