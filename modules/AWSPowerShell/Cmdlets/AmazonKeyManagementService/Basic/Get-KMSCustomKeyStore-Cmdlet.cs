/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Gets information about <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key stores</a> in the account and region.
    /// 
    ///  
    /// <para>
    /// This operation is part of the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">Custom
    /// Key Store feature</a> feature in AWS KMS, which combines the convenience and extensive
    /// integration of AWS KMS with the isolation and control of a single-tenant key store.
    /// </para><para>
    /// By default, this operation returns information about all custom key stores in the
    /// account and region. To get only information about a particular custom key store, use
    /// either the <code>CustomKeyStoreName</code> or <code>CustomKeyStoreId</code> parameter
    /// (but not both).
    /// </para><para>
    /// To determine whether the custom key store is connected to its AWS CloudHSM cluster,
    /// use the <code>ConnectionState</code> element in the response. If an attempt to connect
    /// the custom key store failed, the <code>ConnectionState</code> value is <code>FAILED</code>
    /// and the <code>ConnectionErrorCode</code> element in the response indicates the cause
    /// of the failure. For help interpreting the <code>ConnectionErrorCode</code>, see <a>CustomKeyStoresListEntry</a>.
    /// </para><para>
    /// Custom key stores have a <code>DISCONNECTED</code> connection state if the key store
    /// has never been connected or you use the <a>DisconnectCustomKeyStore</a> operation
    /// to disconnect it. If your custom key store state is <code>CONNECTED</code> but you
    /// are having trouble using it, make sure that its associated AWS CloudHSM cluster is
    /// active and contains the minimum number of HSMs required for the operation, if any.
    /// </para><para>
    ///  For help repairing your custom key store, see the <a href="http://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore-html">Troubleshooting
    /// Custom Key Stores</a> topic in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "KMSCustomKeyStore")]
    [OutputType("Amazon.KeyManagementService.Model.CustomKeyStoresListEntry")]
    [AWSCmdlet("Calls the AWS Key Management Service DescribeCustomKeyStores API operation.", Operation = new[] {"DescribeCustomKeyStores"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.CustomKeyStoresListEntry",
        "This cmdlet returns a collection of CustomKeyStoresListEntry objects.",
        "The service call response (type Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String), Truncated (type System.Boolean)"
    )]
    public partial class GetKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Gets only information about the specified custom key store. Enter the key store ID.</para><para>By default, this operation gets information about all custom key stores in the account
        /// and region. To limit the output to a particular custom key store, you can use either
        /// the <code>CustomKeyStoreId</code> or <code>CustomKeyStoreName</code> parameter, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Gets only information about the specified custom key store. Enter the friendly name
        /// of the custom key store.</para><para>By default, this operation gets information about all custom key stores in the account
        /// and region. To limit the output to a particular custom key store, you can use either
        /// the <code>CustomKeyStoreId</code> or <code>CustomKeyStoreName</code> parameter, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomKeyStoreName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Use this parameter to specify the maximum number of items to return. When this value
        /// is present, AWS KMS does not return more than the specified number of items, but it
        /// might return fewer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter in a subsequent request after you receive a response with truncated
        /// results. Set it to the value of <code>NextMarker</code> from the truncated response
        /// you just received.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextMarker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.CustomKeyStoreName = this.CustomKeyStoreName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Marker = this.Marker;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.KeyManagementService.Model.DescribeCustomKeyStoresRequest();
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
            }
            if (cmdletContext.CustomKeyStoreName != null)
            {
                request.CustomKeyStoreName = cmdletContext.CustomKeyStoreName;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = ParameterWasBound("Marker");
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    int correctPageSize = 1000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(1000, _emitLimit.Value);
                    }
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.CustomKeyStores;
                        notes = new Dictionary<string, object>();
                        notes["NextMarker"] = response.NextMarker;
                        notes["Truncated"] = response.Truncated;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.CustomKeyStores.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextMarker;
                        _retrievedSoFar += _receivedThisCall;
                        if (_emitLimit.HasValue)
                        {
                            _emitLimit -= _receivedThisCall;
                        }
                    }
                    catch (Exception e)
                    {
                        if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                        {
                            output = new CmdletOutput { ErrorResponse = e };
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    ProcessOutput(output);
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DescribeCustomKeyStoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "DescribeCustomKeyStores");
            try
            {
                #if DESKTOP
                return client.DescribeCustomKeyStores(request);
                #elif CORECLR
                return client.DescribeCustomKeyStoresAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomKeyStoreId { get; set; }
            public System.String CustomKeyStoreName { get; set; }
            public int? Limit { get; set; }
            public System.String Marker { get; set; }
        }
        
    }
}
