/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.QLDBSession;
using Amazon.QLDBSession.Model;

namespace Amazon.PowerShell.Cmdlets.QLDBS
{
    /// <summary>
    /// Sends a command to an Amazon QLDB ledger.
    /// </summary>
    [Cmdlet("Send", "QLDBSCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QLDBSession.Model.SendCommandResponse")]
    [AWSCmdlet("Calls the Amazon QLDB Session SendCommand API operation.", Operation = new[] {"SendCommand"}, SelectReturnType = typeof(Amazon.QLDBSession.Model.SendCommandResponse))]
    [AWSCmdletOutput("Amazon.QLDBSession.Model.SendCommandResponse",
        "This cmdlet returns an Amazon.QLDBSession.Model.SendCommandResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendQLDBSCommandCmdlet : AmazonQLDBSessionClientCmdlet, IExecutor
    {
        
        #region Parameter AbortTransaction
        /// <summary>
        /// <para>
        /// <para>Command to abort the current transaction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QLDBSession.Model.AbortTransactionRequest AbortTransaction { get; set; }
        #endregion
        
        #region Parameter CommitTransaction_CommitDigest
        /// <summary>
        /// <para>
        /// <para>Specifies the commit digest for the transaction to commit. For every active transaction,
        /// the commit digest must be passed. QLDB validates <code>CommitDigest</code> and rejects
        /// the commit with an error if the digest computed on the client does not match the digest
        /// computed by QLDB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CommitTransaction_CommitDigest { get; set; }
        #endregion
        
        #region Parameter EndSession
        /// <summary>
        /// <para>
        /// <para>Command to end the current session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QLDBSession.Model.EndSessionRequest EndSession { get; set; }
        #endregion
        
        #region Parameter StartSession_LedgerName
        /// <summary>
        /// <para>
        /// <para>The name of the ledger to start a new session against.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartSession_LedgerName { get; set; }
        #endregion
        
        #region Parameter FetchPage_NextPageToken
        /// <summary>
        /// <para>
        /// <para>Specifies the next page token of the page to be fetched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FetchPage_NextPageToken { get; set; }
        #endregion
        
        #region Parameter ExecuteStatement_Parameter
        /// <summary>
        /// <para>
        /// <para>Specifies the parameters for the parameterized statement in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecuteStatement_Parameters")]
        public Amazon.QLDBSession.Model.ValueHolder[] ExecuteStatement_Parameter { get; set; }
        #endregion
        
        #region Parameter QLDBSessionToken
        /// <summary>
        /// <para>
        /// <para>Specifies the session token for the current command. A session token is constant throughout
        /// the life of the session.</para><para>To obtain a session token, run the <code>StartSession</code> command. This <code>SessionToken</code>
        /// is required for every subsequent command that is issued during the current session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QLDBSessionToken { get; set; }
        #endregion
        
        #region Parameter StartTransaction
        /// <summary>
        /// <para>
        /// <para>Command to start a new transaction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QLDBSession.Model.StartTransactionRequest StartTransaction { get; set; }
        #endregion
        
        #region Parameter ExecuteStatement_Statement
        /// <summary>
        /// <para>
        /// <para>Specifies the statement of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecuteStatement_Statement { get; set; }
        #endregion
        
        #region Parameter CommitTransaction_TransactionId
        /// <summary>
        /// <para>
        /// <para>Specifies the transaction id of the transaction to commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitTransaction_TransactionId { get; set; }
        #endregion
        
        #region Parameter ExecuteStatement_TransactionId
        /// <summary>
        /// <para>
        /// <para>Specifies the transaction id of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecuteStatement_TransactionId { get; set; }
        #endregion
        
        #region Parameter FetchPage_TransactionId
        /// <summary>
        /// <para>
        /// <para>Specifies the transaction id of the page to be fetched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FetchPage_TransactionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDBSession.Model.SendCommandResponse).
        /// Specifying the name of a property of type Amazon.QLDBSession.Model.SendCommandResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-QLDBSCommand (SendCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDBSession.Model.SendCommandResponse, SendQLDBSCommandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AbortTransaction = this.AbortTransaction;
            context.CommitTransaction_CommitDigest = this.CommitTransaction_CommitDigest;
            context.CommitTransaction_TransactionId = this.CommitTransaction_TransactionId;
            context.EndSession = this.EndSession;
            if (this.ExecuteStatement_Parameter != null)
            {
                context.ExecuteStatement_Parameter = new List<Amazon.QLDBSession.Model.ValueHolder>(this.ExecuteStatement_Parameter);
            }
            context.ExecuteStatement_Statement = this.ExecuteStatement_Statement;
            context.ExecuteStatement_TransactionId = this.ExecuteStatement_TransactionId;
            context.FetchPage_NextPageToken = this.FetchPage_NextPageToken;
            context.FetchPage_TransactionId = this.FetchPage_TransactionId;
            context.QLDBSessionToken = this.QLDBSessionToken;
            context.StartSession_LedgerName = this.StartSession_LedgerName;
            context.StartTransaction = this.StartTransaction;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CommitTransaction_CommitDigestStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.QLDBSession.Model.SendCommandRequest();
                
                if (cmdletContext.AbortTransaction != null)
                {
                    request.AbortTransaction = cmdletContext.AbortTransaction;
                }
                
                 // populate CommitTransaction
                var requestCommitTransactionIsNull = true;
                request.CommitTransaction = new Amazon.QLDBSession.Model.CommitTransactionRequest();
                System.IO.MemoryStream requestCommitTransaction_commitTransaction_CommitDigest = null;
                if (cmdletContext.CommitTransaction_CommitDigest != null)
                {
                    _CommitTransaction_CommitDigestStream = new System.IO.MemoryStream(cmdletContext.CommitTransaction_CommitDigest);
                    requestCommitTransaction_commitTransaction_CommitDigest = _CommitTransaction_CommitDigestStream;
                }
                if (requestCommitTransaction_commitTransaction_CommitDigest != null)
                {
                    request.CommitTransaction.CommitDigest = requestCommitTransaction_commitTransaction_CommitDigest;
                    requestCommitTransactionIsNull = false;
                }
                System.String requestCommitTransaction_commitTransaction_TransactionId = null;
                if (cmdletContext.CommitTransaction_TransactionId != null)
                {
                    requestCommitTransaction_commitTransaction_TransactionId = cmdletContext.CommitTransaction_TransactionId;
                }
                if (requestCommitTransaction_commitTransaction_TransactionId != null)
                {
                    request.CommitTransaction.TransactionId = requestCommitTransaction_commitTransaction_TransactionId;
                    requestCommitTransactionIsNull = false;
                }
                 // determine if request.CommitTransaction should be set to null
                if (requestCommitTransactionIsNull)
                {
                    request.CommitTransaction = null;
                }
                if (cmdletContext.EndSession != null)
                {
                    request.EndSession = cmdletContext.EndSession;
                }
                
                 // populate ExecuteStatement
                var requestExecuteStatementIsNull = true;
                request.ExecuteStatement = new Amazon.QLDBSession.Model.ExecuteStatementRequest();
                List<Amazon.QLDBSession.Model.ValueHolder> requestExecuteStatement_executeStatement_Parameter = null;
                if (cmdletContext.ExecuteStatement_Parameter != null)
                {
                    requestExecuteStatement_executeStatement_Parameter = cmdletContext.ExecuteStatement_Parameter;
                }
                if (requestExecuteStatement_executeStatement_Parameter != null)
                {
                    request.ExecuteStatement.Parameters = requestExecuteStatement_executeStatement_Parameter;
                    requestExecuteStatementIsNull = false;
                }
                System.String requestExecuteStatement_executeStatement_Statement = null;
                if (cmdletContext.ExecuteStatement_Statement != null)
                {
                    requestExecuteStatement_executeStatement_Statement = cmdletContext.ExecuteStatement_Statement;
                }
                if (requestExecuteStatement_executeStatement_Statement != null)
                {
                    request.ExecuteStatement.Statement = requestExecuteStatement_executeStatement_Statement;
                    requestExecuteStatementIsNull = false;
                }
                System.String requestExecuteStatement_executeStatement_TransactionId = null;
                if (cmdletContext.ExecuteStatement_TransactionId != null)
                {
                    requestExecuteStatement_executeStatement_TransactionId = cmdletContext.ExecuteStatement_TransactionId;
                }
                if (requestExecuteStatement_executeStatement_TransactionId != null)
                {
                    request.ExecuteStatement.TransactionId = requestExecuteStatement_executeStatement_TransactionId;
                    requestExecuteStatementIsNull = false;
                }
                 // determine if request.ExecuteStatement should be set to null
                if (requestExecuteStatementIsNull)
                {
                    request.ExecuteStatement = null;
                }
                
                 // populate FetchPage
                var requestFetchPageIsNull = true;
                request.FetchPage = new Amazon.QLDBSession.Model.FetchPageRequest();
                System.String requestFetchPage_fetchPage_NextPageToken = null;
                if (cmdletContext.FetchPage_NextPageToken != null)
                {
                    requestFetchPage_fetchPage_NextPageToken = cmdletContext.FetchPage_NextPageToken;
                }
                if (requestFetchPage_fetchPage_NextPageToken != null)
                {
                    request.FetchPage.NextPageToken = requestFetchPage_fetchPage_NextPageToken;
                    requestFetchPageIsNull = false;
                }
                System.String requestFetchPage_fetchPage_TransactionId = null;
                if (cmdletContext.FetchPage_TransactionId != null)
                {
                    requestFetchPage_fetchPage_TransactionId = cmdletContext.FetchPage_TransactionId;
                }
                if (requestFetchPage_fetchPage_TransactionId != null)
                {
                    request.FetchPage.TransactionId = requestFetchPage_fetchPage_TransactionId;
                    requestFetchPageIsNull = false;
                }
                 // determine if request.FetchPage should be set to null
                if (requestFetchPageIsNull)
                {
                    request.FetchPage = null;
                }
                if (cmdletContext.QLDBSessionToken != null)
                {
                    request.SessionToken = cmdletContext.QLDBSessionToken;
                }
                
                 // populate StartSession
                var requestStartSessionIsNull = true;
                request.StartSession = new Amazon.QLDBSession.Model.StartSessionRequest();
                System.String requestStartSession_startSession_LedgerName = null;
                if (cmdletContext.StartSession_LedgerName != null)
                {
                    requestStartSession_startSession_LedgerName = cmdletContext.StartSession_LedgerName;
                }
                if (requestStartSession_startSession_LedgerName != null)
                {
                    request.StartSession.LedgerName = requestStartSession_startSession_LedgerName;
                    requestStartSessionIsNull = false;
                }
                 // determine if request.StartSession should be set to null
                if (requestStartSessionIsNull)
                {
                    request.StartSession = null;
                }
                if (cmdletContext.StartTransaction != null)
                {
                    request.StartTransaction = cmdletContext.StartTransaction;
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
            finally
            {
                if( _CommitTransaction_CommitDigestStream != null)
                {
                    _CommitTransaction_CommitDigestStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.QLDBSession.Model.SendCommandResponse CallAWSServiceOperation(IAmazonQLDBSession client, Amazon.QLDBSession.Model.SendCommandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB Session", "SendCommand");
            try
            {
                #if DESKTOP
                return client.SendCommand(request);
                #elif CORECLR
                return client.SendCommandAsync(request).GetAwaiter().GetResult();
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
            public Amazon.QLDBSession.Model.AbortTransactionRequest AbortTransaction { get; set; }
            public byte[] CommitTransaction_CommitDigest { get; set; }
            public System.String CommitTransaction_TransactionId { get; set; }
            public Amazon.QLDBSession.Model.EndSessionRequest EndSession { get; set; }
            public List<Amazon.QLDBSession.Model.ValueHolder> ExecuteStatement_Parameter { get; set; }
            public System.String ExecuteStatement_Statement { get; set; }
            public System.String ExecuteStatement_TransactionId { get; set; }
            public System.String FetchPage_NextPageToken { get; set; }
            public System.String FetchPage_TransactionId { get; set; }
            public System.String QLDBSessionToken { get; set; }
            public System.String StartSession_LedgerName { get; set; }
            public Amazon.QLDBSession.Model.StartTransactionRequest StartTransaction { get; set; }
            public System.Func<Amazon.QLDBSession.Model.SendCommandResponse, SendQLDBSCommandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
