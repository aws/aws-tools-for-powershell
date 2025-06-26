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
using Amazon.KeyspacesStreams;
using Amazon.KeyspacesStreams.Model;

namespace Amazon.PowerShell.Cmdlets.KST
{
    /// <summary>
    /// Retrieves data records from a specified shard in an Amazon Keyspaces data stream.
    /// This operation returns a collection of data records from the shard, including the
    /// primary key columns and information about modifications made to the captured table
    /// data. Each record represents a single data modification in the Amazon Keyspaces table
    /// and includes metadata about when the change occurred.
    /// </summary>
    [Cmdlet("Get", "KSTRecord")]
    [OutputType("Amazon.KeyspacesStreams.Model.GetRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Keyspaces Streams GetRecords API operation.", Operation = new[] {"GetRecords"}, SelectReturnType = typeof(Amazon.KeyspacesStreams.Model.GetRecordsResponse))]
    [AWSCmdletOutput("Amazon.KeyspacesStreams.Model.GetRecordsResponse",
        "This cmdlet returns an Amazon.KeyspacesStreams.Model.GetRecordsResponse object containing multiple properties."
    )]
    public partial class GetKSTRecordCmdlet : AmazonKeyspacesStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ShardIterator
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the shard iterator. A shard iterator specifies the position
        /// in the shard from which you want to start reading data records sequentially. You obtain
        /// this value by calling the <c>GetShardIterator</c> operation. Each shard iterator is
        /// valid for 5 minutes after creation. </para>
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
        public System.String ShardIterator { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to return in a single <c>GetRecords</c> request. Default
        /// value is 1000. You can specify a limit between 1 and 10000, but the actual number
        /// returned might be less than the specified maximum if the size of the data for the
        /// returned records exceeds the internal size limit. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyspacesStreams.Model.GetRecordsResponse).
        /// Specifying the name of a property of type Amazon.KeyspacesStreams.Model.GetRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ShardIterator parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ShardIterator' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ShardIterator' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.KeyspacesStreams.Model.GetRecordsResponse, GetKSTRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ShardIterator;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.ShardIterator = this.ShardIterator;
            #if MODULAR
            if (this.ShardIterator == null && ParameterWasBound(nameof(this.ShardIterator)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardIterator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyspacesStreams.Model.GetRecordsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ShardIterator != null)
            {
                request.ShardIterator = cmdletContext.ShardIterator;
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
        
        private Amazon.KeyspacesStreams.Model.GetRecordsResponse CallAWSServiceOperation(IAmazonKeyspacesStreams client, Amazon.KeyspacesStreams.Model.GetRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces Streams", "GetRecords");
            try
            {
                #if DESKTOP
                return client.GetRecords(request);
                #elif CORECLR
                return client.GetRecordsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String ShardIterator { get; set; }
            public System.Func<Amazon.KeyspacesStreams.Model.GetRecordsResponse, GetKSTRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
