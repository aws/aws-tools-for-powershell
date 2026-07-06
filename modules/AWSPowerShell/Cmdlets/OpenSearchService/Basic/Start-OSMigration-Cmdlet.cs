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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Initiates a migration job to migrate saved objects from a data source to an Amazon
    /// OpenSearch Service application workspace. Saved objects include dashboards, visualizations,
    /// index patterns, and searches. You can specify export filters to control the scope
    /// of the migration and a conflict resolution strategy for handling existing objects
    /// in the target workspace.
    /// </summary>
    [Cmdlet("Start", "OSMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.StartMigrationResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service StartMigration API operation.", Operation = new[] {"StartMigration"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.StartMigrationResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.StartMigrationResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.StartMigrationResponse object containing multiple properties."
    )]
    public partial class StartOSMigrationCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the OpenSearch application to migrate saved objects into.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_ConflictResolution
        /// <summary>
        /// <para>
        /// <para>The strategy for resolving conflicts when saved objects already exist in the target
        /// workspace. Valid values are <c>CREATE_NEW_COPIES</c>, which creates new objects with
        /// unique IDs, and <c>overwrite</c>, which replaces existing objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOptions_ConflictResolution { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_Workspace_CreateWorkspace
        /// <summary>
        /// <para>
        /// <para>Specifies whether to create a new workspace as the migration target. If <c>true</c>,
        /// you must also specify <c>name</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MigrationOptions_Workspace_CreateWorkspace { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_Source_DatasourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the data source to migrate saved objects from.</para>
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
        public System.String MigrationOptions_Source_DatasourceArn { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_ExportOptions_IncludeReferencesDeep
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include all objects referenced by the exported objects, recursively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MigrationOptions_ExportOptions_IncludeReferencesDeep { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_Workspace_Name
        /// <summary>
        /// <para>
        /// <para>The name of the new workspace to create. Required when <c>createWorkspace</c> is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOptions_Workspace_Name { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_ExportOptions_Object
        /// <summary>
        /// <para>
        /// <para>A list of specific saved objects to include in the migration, identified by type and
        /// ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MigrationOptions_ExportOptions_Objects")]
        public Amazon.OpenSearchService.Model.SavedObjectIdentifier[] MigrationOptions_ExportOptions_Object { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_Workspace_Type
        /// <summary>
        /// <para>
        /// <para>The type of the new workspace to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOptions_Workspace_Type { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_ExportOptions_Type
        /// <summary>
        /// <para>
        /// <para>A list of saved object types to include in the migration. Valid values include <c>dashboard</c>,
        /// <c>visualization</c>, <c>index-pattern</c>, <c>search</c>, and <c>query</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MigrationOptions_ExportOptions_Types")]
        public System.String[] MigrationOptions_ExportOptions_Type { get; set; }
        #endregion
        
        #region Parameter MigrationOptions_Workspace_WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of an existing workspace to use as the migration target. Specify
        /// either this parameter or <c>createWorkspace</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOptions_Workspace_WorkspaceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon OpenSearch Service
        /// ignores the request but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.StartMigrationResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.StartMigrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OSMigration (StartMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.StartMigrationResponse, StartOSMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.MigrationOptions_ConflictResolution = this.MigrationOptions_ConflictResolution;
            context.MigrationOptions_ExportOptions_IncludeReferencesDeep = this.MigrationOptions_ExportOptions_IncludeReferencesDeep;
            if (this.MigrationOptions_ExportOptions_Object != null)
            {
                context.MigrationOptions_ExportOptions_Object = new List<Amazon.OpenSearchService.Model.SavedObjectIdentifier>(this.MigrationOptions_ExportOptions_Object);
            }
            if (this.MigrationOptions_ExportOptions_Type != null)
            {
                context.MigrationOptions_ExportOptions_Type = new List<System.String>(this.MigrationOptions_ExportOptions_Type);
            }
            context.MigrationOptions_Source_DatasourceArn = this.MigrationOptions_Source_DatasourceArn;
            #if MODULAR
            if (this.MigrationOptions_Source_DatasourceArn == null && ParameterWasBound(nameof(this.MigrationOptions_Source_DatasourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationOptions_Source_DatasourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MigrationOptions_Workspace_CreateWorkspace = this.MigrationOptions_Workspace_CreateWorkspace;
            context.MigrationOptions_Workspace_Name = this.MigrationOptions_Workspace_Name;
            context.MigrationOptions_Workspace_Type = this.MigrationOptions_Workspace_Type;
            context.MigrationOptions_Workspace_WorkspaceId = this.MigrationOptions_Workspace_WorkspaceId;
            
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
            var request = new Amazon.OpenSearchService.Model.StartMigrationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate MigrationOptions
            var requestMigrationOptionsIsNull = true;
            request.MigrationOptions = new Amazon.OpenSearchService.Model.MigrationOptions();
            System.String requestMigrationOptions_migrationOptions_ConflictResolution = null;
            if (cmdletContext.MigrationOptions_ConflictResolution != null)
            {
                requestMigrationOptions_migrationOptions_ConflictResolution = cmdletContext.MigrationOptions_ConflictResolution;
            }
            if (requestMigrationOptions_migrationOptions_ConflictResolution != null)
            {
                request.MigrationOptions.ConflictResolution = requestMigrationOptions_migrationOptions_ConflictResolution;
                requestMigrationOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.MigrationSource requestMigrationOptions_migrationOptions_Source = null;
            
             // populate Source
            var requestMigrationOptions_migrationOptions_SourceIsNull = true;
            requestMigrationOptions_migrationOptions_Source = new Amazon.OpenSearchService.Model.MigrationSource();
            System.String requestMigrationOptions_migrationOptions_Source_migrationOptions_Source_DatasourceArn = null;
            if (cmdletContext.MigrationOptions_Source_DatasourceArn != null)
            {
                requestMigrationOptions_migrationOptions_Source_migrationOptions_Source_DatasourceArn = cmdletContext.MigrationOptions_Source_DatasourceArn;
            }
            if (requestMigrationOptions_migrationOptions_Source_migrationOptions_Source_DatasourceArn != null)
            {
                requestMigrationOptions_migrationOptions_Source.DatasourceArn = requestMigrationOptions_migrationOptions_Source_migrationOptions_Source_DatasourceArn;
                requestMigrationOptions_migrationOptions_SourceIsNull = false;
            }
             // determine if requestMigrationOptions_migrationOptions_Source should be set to null
            if (requestMigrationOptions_migrationOptions_SourceIsNull)
            {
                requestMigrationOptions_migrationOptions_Source = null;
            }
            if (requestMigrationOptions_migrationOptions_Source != null)
            {
                request.MigrationOptions.Source = requestMigrationOptions_migrationOptions_Source;
                requestMigrationOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.ExportOptions requestMigrationOptions_migrationOptions_ExportOptions = null;
            
             // populate ExportOptions
            var requestMigrationOptions_migrationOptions_ExportOptionsIsNull = true;
            requestMigrationOptions_migrationOptions_ExportOptions = new Amazon.OpenSearchService.Model.ExportOptions();
            System.Boolean? requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_IncludeReferencesDeep = null;
            if (cmdletContext.MigrationOptions_ExportOptions_IncludeReferencesDeep != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_IncludeReferencesDeep = cmdletContext.MigrationOptions_ExportOptions_IncludeReferencesDeep.Value;
            }
            if (requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_IncludeReferencesDeep != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions.IncludeReferencesDeep = requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_IncludeReferencesDeep.Value;
                requestMigrationOptions_migrationOptions_ExportOptionsIsNull = false;
            }
            List<Amazon.OpenSearchService.Model.SavedObjectIdentifier> requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Object = null;
            if (cmdletContext.MigrationOptions_ExportOptions_Object != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Object = cmdletContext.MigrationOptions_ExportOptions_Object;
            }
            if (requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Object != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions.Objects = requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Object;
                requestMigrationOptions_migrationOptions_ExportOptionsIsNull = false;
            }
            List<System.String> requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Type = null;
            if (cmdletContext.MigrationOptions_ExportOptions_Type != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Type = cmdletContext.MigrationOptions_ExportOptions_Type;
            }
            if (requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Type != null)
            {
                requestMigrationOptions_migrationOptions_ExportOptions.Types = requestMigrationOptions_migrationOptions_ExportOptions_migrationOptions_ExportOptions_Type;
                requestMigrationOptions_migrationOptions_ExportOptionsIsNull = false;
            }
             // determine if requestMigrationOptions_migrationOptions_ExportOptions should be set to null
            if (requestMigrationOptions_migrationOptions_ExportOptionsIsNull)
            {
                requestMigrationOptions_migrationOptions_ExportOptions = null;
            }
            if (requestMigrationOptions_migrationOptions_ExportOptions != null)
            {
                request.MigrationOptions.ExportOptions = requestMigrationOptions_migrationOptions_ExportOptions;
                requestMigrationOptionsIsNull = false;
            }
            Amazon.OpenSearchService.Model.MigrationWorkspace requestMigrationOptions_migrationOptions_Workspace = null;
            
             // populate Workspace
            var requestMigrationOptions_migrationOptions_WorkspaceIsNull = true;
            requestMigrationOptions_migrationOptions_Workspace = new Amazon.OpenSearchService.Model.MigrationWorkspace();
            System.Boolean? requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_CreateWorkspace = null;
            if (cmdletContext.MigrationOptions_Workspace_CreateWorkspace != null)
            {
                requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_CreateWorkspace = cmdletContext.MigrationOptions_Workspace_CreateWorkspace.Value;
            }
            if (requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_CreateWorkspace != null)
            {
                requestMigrationOptions_migrationOptions_Workspace.CreateWorkspace = requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_CreateWorkspace.Value;
                requestMigrationOptions_migrationOptions_WorkspaceIsNull = false;
            }
            System.String requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Name = null;
            if (cmdletContext.MigrationOptions_Workspace_Name != null)
            {
                requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Name = cmdletContext.MigrationOptions_Workspace_Name;
            }
            if (requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Name != null)
            {
                requestMigrationOptions_migrationOptions_Workspace.Name = requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Name;
                requestMigrationOptions_migrationOptions_WorkspaceIsNull = false;
            }
            System.String requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Type = null;
            if (cmdletContext.MigrationOptions_Workspace_Type != null)
            {
                requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Type = cmdletContext.MigrationOptions_Workspace_Type;
            }
            if (requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Type != null)
            {
                requestMigrationOptions_migrationOptions_Workspace.Type = requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_Type;
                requestMigrationOptions_migrationOptions_WorkspaceIsNull = false;
            }
            System.String requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_WorkspaceId = null;
            if (cmdletContext.MigrationOptions_Workspace_WorkspaceId != null)
            {
                requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_WorkspaceId = cmdletContext.MigrationOptions_Workspace_WorkspaceId;
            }
            if (requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_WorkspaceId != null)
            {
                requestMigrationOptions_migrationOptions_Workspace.WorkspaceId = requestMigrationOptions_migrationOptions_Workspace_migrationOptions_Workspace_WorkspaceId;
                requestMigrationOptions_migrationOptions_WorkspaceIsNull = false;
            }
             // determine if requestMigrationOptions_migrationOptions_Workspace should be set to null
            if (requestMigrationOptions_migrationOptions_WorkspaceIsNull)
            {
                requestMigrationOptions_migrationOptions_Workspace = null;
            }
            if (requestMigrationOptions_migrationOptions_Workspace != null)
            {
                request.MigrationOptions.Workspace = requestMigrationOptions_migrationOptions_Workspace;
                requestMigrationOptionsIsNull = false;
            }
             // determine if request.MigrationOptions should be set to null
            if (requestMigrationOptionsIsNull)
            {
                request.MigrationOptions = null;
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
        
        private Amazon.OpenSearchService.Model.StartMigrationResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.StartMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "StartMigration");
            try
            {
                return client.StartMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String MigrationOptions_ConflictResolution { get; set; }
            public System.Boolean? MigrationOptions_ExportOptions_IncludeReferencesDeep { get; set; }
            public List<Amazon.OpenSearchService.Model.SavedObjectIdentifier> MigrationOptions_ExportOptions_Object { get; set; }
            public List<System.String> MigrationOptions_ExportOptions_Type { get; set; }
            public System.String MigrationOptions_Source_DatasourceArn { get; set; }
            public System.Boolean? MigrationOptions_Workspace_CreateWorkspace { get; set; }
            public System.String MigrationOptions_Workspace_Name { get; set; }
            public System.String MigrationOptions_Workspace_Type { get; set; }
            public System.String MigrationOptions_Workspace_WorkspaceId { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.StartMigrationResponse, StartOSMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
