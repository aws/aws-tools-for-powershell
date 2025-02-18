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

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Gets details about a maintenance configuration for a given table bucket. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-table-buckets-maintenance.html">Amazon
    /// S3 table bucket maintenance</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:GetTableBucketMaintenanceConfiguration</c> permission
    /// to use this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3TTableBucketMaintenanceConfiguration")]
    [OutputType("Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables GetTableBucketMaintenanceConfiguration API operation.", Operation = new[] {"GetTableBucketMaintenanceConfiguration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse object containing multiple properties."
    )]
    public partial class GetS3TTableBucketMaintenanceConfigurationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket associated with the maintenance
        /// configuration.</para>
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse, GetS3TTableBucketMaintenanceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationRequest();
            
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
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
        
        private Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "GetTableBucketMaintenanceConfiguration");
            try
            {
                return client.GetTableBucketMaintenanceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TableBucketARN { get; set; }
            public System.Func<Amazon.S3Tables.Model.GetTableBucketMaintenanceConfigurationResponse, GetS3TTableBucketMaintenanceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
