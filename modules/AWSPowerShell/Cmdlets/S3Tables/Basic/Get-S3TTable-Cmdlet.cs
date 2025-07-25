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
    /// Gets details about a table. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-tables.html">S3
    /// Tables</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:GetTable</c> permission to use this operation. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3TTable")]
    [OutputType("Amazon.S3Tables.Model.GetTableResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables GetTable API operation.", Operation = new[] {"GetTable"}, SelectReturnType = typeof(Amazon.S3Tables.Model.GetTableResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.GetTableResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.GetTableResponse object containing multiple properties."
    )]
    public partial class GetS3TTableCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The name of the namespace the table is associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableArn { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket associated with the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.GetTableResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.GetTableResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.GetTableResponse, GetS3TTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.Namespace = this.Namespace;
            context.TableArn = this.TableArn;
            context.TableBucketARN = this.TableBucketARN;
            
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
            var request = new Amazon.S3Tables.Model.GetTableRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.TableArn != null)
            {
                request.TableArn = cmdletContext.TableArn;
            }
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
        
        private Amazon.S3Tables.Model.GetTableResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.GetTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "GetTable");
            try
            {
                return client.GetTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public System.String TableArn { get; set; }
            public System.String TableBucketARN { get; set; }
            public System.Func<Amazon.S3Tables.Model.GetTableResponse, GetS3TTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
