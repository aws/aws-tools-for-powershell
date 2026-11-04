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
    /// Gets the details of a migration, including its state, the reason it failed, its statistics
    /// and the location of its reports. Identify the migration by its <c>migrationId</c>,
    /// or specify the <c>tableARN</c> of a destination table to get that table's most recent
    /// migration.
    /// 
    ///  <dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:GetTableMigration</c> permission to use this operation.
    /// </para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3TTableMigration")]
    [OutputType("Amazon.S3Tables.Model.GetTableMigrationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables GetTableMigration API operation.", Operation = new[] {"GetTableMigration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.GetTableMigrationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.GetTableMigrationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.GetTableMigrationResponse object containing multiple properties."
    )]
    public partial class GetS3TTableMigrationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationId
        /// <summary>
        /// <para>
        /// <para>The ID of the migration to get. Specify either <c>migrationId</c> or <c>tableARN</c>,
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationId { get; set; }
        #endregion
        
        #region Parameter TableARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination table. Gets the table's most recent
        /// migration. Specify either <c>tableARN</c> or <c>migrationId</c>, not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.GetTableMigrationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.GetTableMigrationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.GetTableMigrationResponse, GetS3TTableMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MigrationId = this.MigrationId;
            context.TableARN = this.TableARN;
            
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
            var request = new Amazon.S3Tables.Model.GetTableMigrationRequest();
            
            if (cmdletContext.MigrationId != null)
            {
                request.MigrationId = cmdletContext.MigrationId;
            }
            if (cmdletContext.TableARN != null)
            {
                request.TableARN = cmdletContext.TableARN;
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
        
        private Amazon.S3Tables.Model.GetTableMigrationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.GetTableMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "GetTableMigration");
            try
            {
                return client.GetTableMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MigrationId { get; set; }
            public System.String TableARN { get; set; }
            public System.Func<Amazon.S3Tables.Model.GetTableMigrationResponse, GetS3TTableMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
