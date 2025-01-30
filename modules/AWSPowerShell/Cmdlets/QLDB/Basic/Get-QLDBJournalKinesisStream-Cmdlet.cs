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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Returns detailed information about a given Amazon QLDB journal stream. The output
    /// includes the Amazon Resource Name (ARN), stream name, current status, creation time,
    /// and the parameters of the original stream creation request.
    /// 
    ///  
    /// <para>
    /// This action does not return any expired journal streams. For more information, see
    /// <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/streams.create.html#streams.create.states.expiration">Expiration
    /// for terminal streams</a> in the <i>Amazon QLDB Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "QLDBJournalKinesisStream")]
    [OutputType("Amazon.QLDB.Model.JournalKinesisStreamDescription")]
    [AWSCmdlet("Calls the Amazon QLDB DescribeJournalKinesisStream API operation.", Operation = new[] {"DescribeJournalKinesisStream"}, SelectReturnType = typeof(Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.JournalKinesisStreamDescription or Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse",
        "This cmdlet returns an Amazon.QLDB.Model.JournalKinesisStreamDescription object.",
        "The service call response (type Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetQLDBJournalKinesisStreamCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LedgerName
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String LedgerName { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para>The UUID (represented in Base62-encoded text) of the QLDB journal stream to describe.</para>
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
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stream";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse, GetQLDBJournalKinesisStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LedgerName = this.LedgerName;
            #if MODULAR
            if (this.LedgerName == null && ParameterWasBound(nameof(this.LedgerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LedgerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamId = this.StreamId;
            #if MODULAR
            if (this.StreamId == null && ParameterWasBound(nameof(this.StreamId)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QLDB.Model.DescribeJournalKinesisStreamRequest();
            
            if (cmdletContext.LedgerName != null)
            {
                request.LedgerName = cmdletContext.LedgerName;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
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
        
        private Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.DescribeJournalKinesisStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "DescribeJournalKinesisStream");
            try
            {
                #if DESKTOP
                return client.DescribeJournalKinesisStream(request);
                #elif CORECLR
                return client.DescribeJournalKinesisStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String LedgerName { get; set; }
            public System.String StreamId { get; set; }
            public System.Func<Amazon.QLDB.Model.DescribeJournalKinesisStreamResponse, GetQLDBJournalKinesisStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stream;
        }
        
    }
}
