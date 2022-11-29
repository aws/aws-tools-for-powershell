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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Gets information about <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key stores</a> in the account and Region.
    /// 
    ///  
    /// <para>
    ///  This operation is part of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key stores</a> feature in KMS, which combines the convenience and extensive integration
    /// of KMS with the isolation and control of a key store that you own and manage.
    /// </para><para>
    /// By default, this operation returns information about all custom key stores in the
    /// account and Region. To get only information about a particular custom key store, use
    /// either the <code>CustomKeyStoreName</code> or <code>CustomKeyStoreId</code> parameter
    /// (but not both).
    /// </para><para>
    /// To determine whether the custom key store is connected to its CloudHSM cluster or
    /// external key store proxy, use the <code>ConnectionState</code> element in the response.
    /// If an attempt to connect the custom key store failed, the <code>ConnectionState</code>
    /// value is <code>FAILED</code> and the <code>ConnectionErrorCode</code> element in the
    /// response indicates the cause of the failure. For help interpreting the <code>ConnectionErrorCode</code>,
    /// see <a>CustomKeyStoresListEntry</a>.
    /// </para><para>
    /// Custom key stores have a <code>DISCONNECTED</code> connection state if the key store
    /// has never been connected or you used the <a>DisconnectCustomKeyStore</a> operation
    /// to disconnect it. Otherwise, the connection state is CONNECTED. If your custom key
    /// store connection state is <code>CONNECTED</code> but you are having trouble using
    /// it, verify that the backing store is active and available. For an CloudHSM key store,
    /// verify that the associated CloudHSM cluster is active and contains the minimum number
    /// of HSMs required for the operation, if any. For an external key store, verify that
    /// the external key store proxy and its associated external key manager are reachable
    /// and enabled.
    /// </para><para>
    ///  For help repairing your CloudHSM key store, see the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshooting
    /// CloudHSM key stores</a>. For help repairing your external key store, see the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/xks-troubleshooting.html">Troubleshooting
    /// external key stores</a>. Both topics are in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a custom key store
    /// in a different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:DescribeCustomKeyStores</a>
    /// (IAM policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ConnectCustomKeyStore</a></para></li><li><para><a>CreateCustomKeyStore</a></para></li><li><para><a>DeleteCustomKeyStore</a></para></li><li><para><a>DisconnectCustomKeyStore</a></para></li><li><para><a>UpdateCustomKeyStore</a></para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KMSCustomKeyStore")]
    [OutputType("Amazon.KeyManagementService.Model.CustomKeyStoresListEntry")]
    [AWSCmdlet("Calls the AWS Key Management Service DescribeCustomKeyStores API operation.", Operation = new[] {"DescribeCustomKeyStores"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.CustomKeyStoresListEntry or Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse",
        "This cmdlet returns a collection of Amazon.KeyManagementService.Model.CustomKeyStoresListEntry objects.",
        "The service call response (type Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Gets only information about the specified custom key store. Enter the key store ID.</para><para>By default, this operation gets information about all custom key stores in the account
        /// and Region. To limit the output to a particular custom key store, provide either the
        /// <code>CustomKeyStoreId</code> or <code>CustomKeyStoreName</code> parameter, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Gets only information about the specified custom key store. Enter the friendly name
        /// of the custom key store.</para><para>By default, this operation gets information about all custom key stores in the account
        /// and Region. To limit the output to a particular custom key store, provide either the
        /// <code>CustomKeyStoreId</code> or <code>CustomKeyStoreName</code> parameter, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomKeyStoreName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Use this parameter to specify the maximum number of items to return. When this value
        /// is present, KMS does not return more than the specified number of items, but it might
        /// return fewer.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.NextMarker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomKeyStores'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomKeyStores";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomKeyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse, GetKMSCustomKeyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomKeyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.CustomKeyStoreName = this.CustomKeyStoreName;
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.Marker = this.Marker;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.CustomKeyStores.Count;
                    
                    _nextToken = response.NextMarker;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
            public System.Func<Amazon.KeyManagementService.Model.DescribeCustomKeyStoresResponse, GetKMSCustomKeyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomKeyStores;
        }
        
    }
}
