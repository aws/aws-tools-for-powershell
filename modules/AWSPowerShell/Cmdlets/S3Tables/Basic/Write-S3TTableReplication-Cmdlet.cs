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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Creates or updates the replication configuration for a specific table. This operation
    /// allows you to define table-level replication independently of bucket-level replication,
    /// providing granular control over which tables are replicated and where.
    /// 
    ///  <dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:PutTableReplication</c> permission to use this operation.
    /// The IAM role specified in the configuration must have permissions to read from the
    /// source table and write to all destination tables.
    /// </para></li><li><para>
    /// You must also have the following permissions:
    /// </para><ul><li><para><c>s3tables:GetTable</c> permission on the source table being replicated.
    /// </para></li><li><para><c>s3tables:CreateTable</c> permission for the destination.
    /// </para></li><li><para><c>s3tables:CreateNamespace</c> permission for the destination.
    /// </para></li><li><para><c>s3tables:GetTableMaintenanceConfig</c> permission for the source table.
    /// </para></li><li><para><c>s3tables:PutTableMaintenanceConfig</c> permission for the destination table.
    /// </para></li></ul></li><li><para>
    /// You must have <c>iam:PassRole</c> permission with condition allowing roles to be passed
    /// to <c>replication.s3tables.amazonaws.com</c>.
    /// </para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.PutTableReplicationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableReplication API operation.", Operation = new[] {"PutTableReplication"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableReplicationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.PutTableReplicationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.PutTableReplicationResponse object containing multiple properties."
    )]
    public partial class WriteS3TTableReplicationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that S3 Tables assumes to replicate
        /// the table on your behalf.</para>
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
        public System.String Configuration_Role { get; set; }
        #endregion
        
        #region Parameter Configuration_Rule
        /// <summary>
        /// <para>
        /// <para>An array of replication rules that define where this table should be replicated.</para><para />
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
        [Alias("Configuration_Rules")]
        public Amazon.S3Tables.Model.TableReplicationRule[] Configuration_Rule { get; set; }
        #endregion
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source table.</para>
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
        public System.String TableArn { get; set; }
        #endregion
        
        #region Parameter VersionToken
        /// <summary>
        /// <para>
        /// <para>A version token from a previous GetTableReplication call. Use this token to ensure
        /// you're updating the expected version of the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableReplicationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.PutTableReplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableReplication (PutTableReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableReplicationResponse, WriteS3TTableReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_Role = this.Configuration_Role;
            #if MODULAR
            if (this.Configuration_Role == null && ParameterWasBound(nameof(this.Configuration_Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Configuration_Rule != null)
            {
                context.Configuration_Rule = new List<Amazon.S3Tables.Model.TableReplicationRule>(this.Configuration_Rule);
            }
            #if MODULAR
            if (this.Configuration_Rule == null && ParameterWasBound(nameof(this.Configuration_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableArn = this.TableArn;
            #if MODULAR
            if (this.TableArn == null && ParameterWasBound(nameof(this.TableArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TableArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionToken = this.VersionToken;
            
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
            var request = new Amazon.S3Tables.Model.PutTableReplicationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.S3Tables.Model.TableReplicationConfiguration();
            System.String requestConfiguration_configuration_Role = null;
            if (cmdletContext.Configuration_Role != null)
            {
                requestConfiguration_configuration_Role = cmdletContext.Configuration_Role;
            }
            if (requestConfiguration_configuration_Role != null)
            {
                request.Configuration.Role = requestConfiguration_configuration_Role;
                requestConfigurationIsNull = false;
            }
            List<Amazon.S3Tables.Model.TableReplicationRule> requestConfiguration_configuration_Rule = null;
            if (cmdletContext.Configuration_Rule != null)
            {
                requestConfiguration_configuration_Rule = cmdletContext.Configuration_Rule;
            }
            if (requestConfiguration_configuration_Rule != null)
            {
                request.Configuration.Rules = requestConfiguration_configuration_Rule;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.TableArn != null)
            {
                request.TableArn = cmdletContext.TableArn;
            }
            if (cmdletContext.VersionToken != null)
            {
                request.VersionToken = cmdletContext.VersionToken;
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
        
        private Amazon.S3Tables.Model.PutTableReplicationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableReplication");
            try
            {
                return client.PutTableReplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_Role { get; set; }
            public List<Amazon.S3Tables.Model.TableReplicationRule> Configuration_Rule { get; set; }
            public System.String TableArn { get; set; }
            public System.String VersionToken { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableReplicationResponse, WriteS3TTableReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
