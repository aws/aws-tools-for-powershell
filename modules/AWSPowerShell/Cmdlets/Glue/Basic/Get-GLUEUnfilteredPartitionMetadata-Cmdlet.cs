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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieves partition metadata from the Data Catalog that contains unfiltered metadata.
    /// 
    ///  
    /// <para>
    /// For IAM authorization, the public IAM action associated with this API is <c>glue:GetPartition</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GLUEUnfilteredPartitionMetadata")]
    [OutputType("Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse")]
    [AWSCmdlet("Calls the AWS Glue GetUnfilteredPartitionMetadata API operation.", Operation = new[] {"GetUnfilteredPartitionMetadata"}, SelectReturnType = typeof(Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse",
        "This cmdlet returns an Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse object containing multiple properties."
    )]
    public partial class GetGLUEUnfilteredPartitionMetadataCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuditContext_AdditionalAuditContext
        /// <summary>
        /// <para>
        /// <para>A string containing the additional audit context information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditContext_AdditionalAuditContext { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_AdditionalContext
        /// <summary>
        /// <para>
        /// <para>An opaque string-string map passed by the query engine.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable QuerySessionContext_AdditionalContext { get; set; }
        #endregion
        
        #region Parameter AuditContext_AllColumnsRequested
        /// <summary>
        /// <para>
        /// <para>All columns request for audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AuditContext_AllColumnsRequested { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog ID where the partition resides.</para>
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
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_ClusterId
        /// <summary>
        /// <para>
        /// <para>An identifier string for the consumer cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_ClusterId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>(Required) Specifies the name of a database that contains the partition.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter PartitionValue
        /// <summary>
        /// <para>
        /// <para>(Required) A list of partition key values.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("PartitionValues")]
        public System.String[] PartitionValue { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryAuthorizationId
        /// <summary>
        /// <para>
        /// <para>A cryptographically generated query identifier generated by Glue or Lake Formation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_QueryAuthorizationId { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryId
        /// <summary>
        /// <para>
        /// <para>A unique identifier generated by the query engine for the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_QueryId { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryStartTime
        /// <summary>
        /// <para>
        /// <para>A timestamp provided by the query engine for when the query started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? QuerySessionContext_QueryStartTime { get; set; }
        #endregion
        
        #region Parameter ResourceRegion
        /// <summary>
        /// <para>
        /// <para>Specified only if the base tables belong to a different Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceRegion { get; set; }
        #endregion
        
        #region Parameter AuditContext_RequestedColumn
        /// <summary>
        /// <para>
        /// <para>The requested columns for audit.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuditContext_RequestedColumns")]
        public System.String[] AuditContext_RequestedColumn { get; set; }
        #endregion
        
        #region Parameter SupportedPermissionType
        /// <summary>
        /// <para>
        /// <para>(Required) A list of supported permission types. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("SupportedPermissionTypes")]
        public System.String[] SupportedPermissionType { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>(Required) Specifies the name of a table that contains the partition.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse, GetGLUEUnfilteredPartitionMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuditContext_AdditionalAuditContext = this.AuditContext_AdditionalAuditContext;
            context.AuditContext_AllColumnsRequested = this.AuditContext_AllColumnsRequested;
            if (this.AuditContext_RequestedColumn != null)
            {
                context.AuditContext_RequestedColumn = new List<System.String>(this.AuditContext_RequestedColumn);
            }
            context.CatalogId = this.CatalogId;
            #if MODULAR
            if (this.CatalogId == null && ParameterWasBound(nameof(this.CatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter CatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PartitionValue != null)
            {
                context.PartitionValue = new List<System.String>(this.PartitionValue);
            }
            #if MODULAR
            if (this.PartitionValue == null && ParameterWasBound(nameof(this.PartitionValue)))
            {
                WriteWarning("You are passing $null as a value for parameter PartitionValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.QuerySessionContext_AdditionalContext != null)
            {
                context.QuerySessionContext_AdditionalContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QuerySessionContext_AdditionalContext.Keys)
                {
                    context.QuerySessionContext_AdditionalContext.Add((String)hashKey, (System.String)(this.QuerySessionContext_AdditionalContext[hashKey]));
                }
            }
            context.QuerySessionContext_ClusterId = this.QuerySessionContext_ClusterId;
            context.QuerySessionContext_QueryAuthorizationId = this.QuerySessionContext_QueryAuthorizationId;
            context.QuerySessionContext_QueryId = this.QuerySessionContext_QueryId;
            context.QuerySessionContext_QueryStartTime = this.QuerySessionContext_QueryStartTime;
            context.ResourceRegion = this.ResourceRegion;
            if (this.SupportedPermissionType != null)
            {
                context.SupportedPermissionType = new List<System.String>(this.SupportedPermissionType);
            }
            #if MODULAR
            if (this.SupportedPermissionType == null && ParameterWasBound(nameof(this.SupportedPermissionType)))
            {
                WriteWarning("You are passing $null as a value for parameter SupportedPermissionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.GetUnfilteredPartitionMetadataRequest();
            
            
             // populate AuditContext
            var requestAuditContextIsNull = true;
            request.AuditContext = new Amazon.Glue.Model.AuditContext();
            System.String requestAuditContext_auditContext_AdditionalAuditContext = null;
            if (cmdletContext.AuditContext_AdditionalAuditContext != null)
            {
                requestAuditContext_auditContext_AdditionalAuditContext = cmdletContext.AuditContext_AdditionalAuditContext;
            }
            if (requestAuditContext_auditContext_AdditionalAuditContext != null)
            {
                request.AuditContext.AdditionalAuditContext = requestAuditContext_auditContext_AdditionalAuditContext;
                requestAuditContextIsNull = false;
            }
            System.Boolean? requestAuditContext_auditContext_AllColumnsRequested = null;
            if (cmdletContext.AuditContext_AllColumnsRequested != null)
            {
                requestAuditContext_auditContext_AllColumnsRequested = cmdletContext.AuditContext_AllColumnsRequested.Value;
            }
            if (requestAuditContext_auditContext_AllColumnsRequested != null)
            {
                request.AuditContext.AllColumnsRequested = requestAuditContext_auditContext_AllColumnsRequested.Value;
                requestAuditContextIsNull = false;
            }
            List<System.String> requestAuditContext_auditContext_RequestedColumn = null;
            if (cmdletContext.AuditContext_RequestedColumn != null)
            {
                requestAuditContext_auditContext_RequestedColumn = cmdletContext.AuditContext_RequestedColumn;
            }
            if (requestAuditContext_auditContext_RequestedColumn != null)
            {
                request.AuditContext.RequestedColumns = requestAuditContext_auditContext_RequestedColumn;
                requestAuditContextIsNull = false;
            }
             // determine if request.AuditContext should be set to null
            if (requestAuditContextIsNull)
            {
                request.AuditContext = null;
            }
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.PartitionValue != null)
            {
                request.PartitionValues = cmdletContext.PartitionValue;
            }
            
             // populate QuerySessionContext
            var requestQuerySessionContextIsNull = true;
            request.QuerySessionContext = new Amazon.Glue.Model.QuerySessionContext();
            Dictionary<System.String, System.String> requestQuerySessionContext_querySessionContext_AdditionalContext = null;
            if (cmdletContext.QuerySessionContext_AdditionalContext != null)
            {
                requestQuerySessionContext_querySessionContext_AdditionalContext = cmdletContext.QuerySessionContext_AdditionalContext;
            }
            if (requestQuerySessionContext_querySessionContext_AdditionalContext != null)
            {
                request.QuerySessionContext.AdditionalContext = requestQuerySessionContext_querySessionContext_AdditionalContext;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_ClusterId = null;
            if (cmdletContext.QuerySessionContext_ClusterId != null)
            {
                requestQuerySessionContext_querySessionContext_ClusterId = cmdletContext.QuerySessionContext_ClusterId;
            }
            if (requestQuerySessionContext_querySessionContext_ClusterId != null)
            {
                request.QuerySessionContext.ClusterId = requestQuerySessionContext_querySessionContext_ClusterId;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_QueryAuthorizationId = null;
            if (cmdletContext.QuerySessionContext_QueryAuthorizationId != null)
            {
                requestQuerySessionContext_querySessionContext_QueryAuthorizationId = cmdletContext.QuerySessionContext_QueryAuthorizationId;
            }
            if (requestQuerySessionContext_querySessionContext_QueryAuthorizationId != null)
            {
                request.QuerySessionContext.QueryAuthorizationId = requestQuerySessionContext_querySessionContext_QueryAuthorizationId;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_QueryId = null;
            if (cmdletContext.QuerySessionContext_QueryId != null)
            {
                requestQuerySessionContext_querySessionContext_QueryId = cmdletContext.QuerySessionContext_QueryId;
            }
            if (requestQuerySessionContext_querySessionContext_QueryId != null)
            {
                request.QuerySessionContext.QueryId = requestQuerySessionContext_querySessionContext_QueryId;
                requestQuerySessionContextIsNull = false;
            }
            System.DateTime? requestQuerySessionContext_querySessionContext_QueryStartTime = null;
            if (cmdletContext.QuerySessionContext_QueryStartTime != null)
            {
                requestQuerySessionContext_querySessionContext_QueryStartTime = cmdletContext.QuerySessionContext_QueryStartTime.Value;
            }
            if (requestQuerySessionContext_querySessionContext_QueryStartTime != null)
            {
                request.QuerySessionContext.QueryStartTime = requestQuerySessionContext_querySessionContext_QueryStartTime.Value;
                requestQuerySessionContextIsNull = false;
            }
             // determine if request.QuerySessionContext should be set to null
            if (requestQuerySessionContextIsNull)
            {
                request.QuerySessionContext = null;
            }
            if (cmdletContext.ResourceRegion != null)
            {
                request.Region = cmdletContext.ResourceRegion;
            }
            if (cmdletContext.SupportedPermissionType != null)
            {
                request.SupportedPermissionTypes = cmdletContext.SupportedPermissionType;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetUnfilteredPartitionMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetUnfilteredPartitionMetadata");
            try
            {
                return client.GetUnfilteredPartitionMetadataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuditContext_AdditionalAuditContext { get; set; }
            public System.Boolean? AuditContext_AllColumnsRequested { get; set; }
            public List<System.String> AuditContext_RequestedColumn { get; set; }
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public List<System.String> PartitionValue { get; set; }
            public Dictionary<System.String, System.String> QuerySessionContext_AdditionalContext { get; set; }
            public System.String QuerySessionContext_ClusterId { get; set; }
            public System.String QuerySessionContext_QueryAuthorizationId { get; set; }
            public System.String QuerySessionContext_QueryId { get; set; }
            public System.DateTime? QuerySessionContext_QueryStartTime { get; set; }
            public System.String ResourceRegion { get; set; }
            public List<System.String> SupportedPermissionType { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.Glue.Model.GetUnfilteredPartitionMetadataResponse, GetGLUEUnfilteredPartitionMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
