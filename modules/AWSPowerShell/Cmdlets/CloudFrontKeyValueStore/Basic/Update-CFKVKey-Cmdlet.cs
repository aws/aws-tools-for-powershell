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
using Amazon.CloudFrontKeyValueStore;
using Amazon.CloudFrontKeyValueStore.Model;

namespace Amazon.PowerShell.Cmdlets.CFKV
{
    /// <summary>
    /// Puts or Deletes multiple key value pairs in a single, all-or-nothing operation.
    /// </summary>
    [Cmdlet("Update", "CFKVKey")]
    [OutputType("Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront KeyValueStore UpdateKeys API operation.", Operation = new[] {"UpdateKeys"}, SelectReturnType = typeof(Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse))]
    [AWSCmdletOutput("Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse",
        "This cmdlet returns an Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse object containing multiple properties."
    )]
    public partial class UpdateCFKVKeyCmdlet : AmazonCloudFrontKeyValueStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Delete
        /// <summary>
        /// <para>
        /// <para>List of keys to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deletes")]
        public Amazon.CloudFrontKeyValueStore.Model.DeleteKeyRequestListItem[] Delete { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current version (ETag) of the Key Value Store that you are updating keys of, which
        /// you can get using DescribeKeyValueStore.</para>
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
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter KvsARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Key Value Store.</para>
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
        public System.String KvsARN { get; set; }
        #endregion
        
        #region Parameter Put
        /// <summary>
        /// <para>
        /// <para>List of key value pairs to put.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Puts")]
        public Amazon.CloudFrontKeyValueStore.Model.PutKeyRequestListItem[] Put { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse).
        /// Specifying the name of a property of type Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KvsARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KvsARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KvsARN' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse, UpdateCFKVKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KvsARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Delete != null)
            {
                context.Delete = new List<Amazon.CloudFrontKeyValueStore.Model.DeleteKeyRequestListItem>(this.Delete);
            }
            context.IfMatch = this.IfMatch;
            #if MODULAR
            if (this.IfMatch == null && ParameterWasBound(nameof(this.IfMatch)))
            {
                WriteWarning("You are passing $null as a value for parameter IfMatch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KvsARN = this.KvsARN;
            #if MODULAR
            if (this.KvsARN == null && ParameterWasBound(nameof(this.KvsARN)))
            {
                WriteWarning("You are passing $null as a value for parameter KvsARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Put != null)
            {
                context.Put = new List<Amazon.CloudFrontKeyValueStore.Model.PutKeyRequestListItem>(this.Put);
            }
            
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
            var request = new Amazon.CloudFrontKeyValueStore.Model.UpdateKeysRequest();
            
            if (cmdletContext.Delete != null)
            {
                request.Deletes = cmdletContext.Delete;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            if (cmdletContext.KvsARN != null)
            {
                request.KvsARN = cmdletContext.KvsARN;
            }
            if (cmdletContext.Put != null)
            {
                request.Puts = cmdletContext.Put;
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
        
        private Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse CallAWSServiceOperation(IAmazonCloudFrontKeyValueStore client, Amazon.CloudFrontKeyValueStore.Model.UpdateKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront KeyValueStore", "UpdateKeys");
            try
            {
                #if DESKTOP
                return client.UpdateKeys(request);
                #elif CORECLR
                return client.UpdateKeysAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudFrontKeyValueStore.Model.DeleteKeyRequestListItem> Delete { get; set; }
            public System.String IfMatch { get; set; }
            public System.String KvsARN { get; set; }
            public List<Amazon.CloudFrontKeyValueStore.Model.PutKeyRequestListItem> Put { get; set; }
            public System.Func<Amazon.CloudFrontKeyValueStore.Model.UpdateKeysResponse, UpdateCFKVKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
