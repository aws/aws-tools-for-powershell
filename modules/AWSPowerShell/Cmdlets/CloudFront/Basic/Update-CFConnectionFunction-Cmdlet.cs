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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a connection function.
    /// </summary>
    [Cmdlet("Update", "CFConnectionFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.ConnectionFunctionSummary")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateConnectionFunction API operation.", Operation = new[] {"UpdateConnectionFunction"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateConnectionFunctionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.ConnectionFunctionSummary or Amazon.CloudFront.Model.UpdateConnectionFunctionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.ConnectionFunctionSummary object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateConnectionFunctionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFConnectionFunctionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionFunctionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the function.</para>
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
        public System.String ConnectionFunctionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter ConnectionFunctionCode
        /// <summary>
        /// <para>
        /// <para>The connection function code.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ConnectionFunctionCode { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The connection function ID.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current version (<c>ETag</c> value) of the connection function you are updating.</para>
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
        
        #region Parameter KeyValueStoreAssociations_Item
        /// <summary>
        /// <para>
        /// <para>The items of the key value store association.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionFunctionConfig_KeyValueStoreAssociations_Items")]
        public Amazon.CloudFront.Model.KeyValueStoreAssociation[] KeyValueStoreAssociations_Item { get; set; }
        #endregion
        
        #region Parameter KeyValueStoreAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The quantity of key value store associations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionFunctionConfig_KeyValueStoreAssociations_Quantity")]
        public System.Int32? KeyValueStoreAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter ConnectionFunctionConfig_Runtime
        /// <summary>
        /// <para>
        /// <para>The function's runtime environment version.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudFront.FunctionRuntime")]
        public Amazon.CloudFront.FunctionRuntime ConnectionFunctionConfig_Runtime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectionFunctionSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateConnectionFunctionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateConnectionFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectionFunctionSummary";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFConnectionFunction (UpdateConnectionFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateConnectionFunctionResponse, UpdateCFConnectionFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionFunctionCode = this.ConnectionFunctionCode;
            #if MODULAR
            if (this.ConnectionFunctionCode == null && ParameterWasBound(nameof(this.ConnectionFunctionCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionFunctionCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionFunctionConfig_Comment = this.ConnectionFunctionConfig_Comment;
            #if MODULAR
            if (this.ConnectionFunctionConfig_Comment == null && ParameterWasBound(nameof(this.ConnectionFunctionConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionFunctionConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.KeyValueStoreAssociations_Item != null)
            {
                context.KeyValueStoreAssociations_Item = new List<Amazon.CloudFront.Model.KeyValueStoreAssociation>(this.KeyValueStoreAssociations_Item);
            }
            context.KeyValueStoreAssociations_Quantity = this.KeyValueStoreAssociations_Quantity;
            context.ConnectionFunctionConfig_Runtime = this.ConnectionFunctionConfig_Runtime;
            #if MODULAR
            if (this.ConnectionFunctionConfig_Runtime == null && ParameterWasBound(nameof(this.ConnectionFunctionConfig_Runtime)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionFunctionConfig_Runtime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            #if MODULAR
            if (this.IfMatch == null && ParameterWasBound(nameof(this.IfMatch)))
            {
                WriteWarning("You are passing $null as a value for parameter IfMatch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _ConnectionFunctionCodeStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CloudFront.Model.UpdateConnectionFunctionRequest();
                
                if (cmdletContext.ConnectionFunctionCode != null)
                {
                    _ConnectionFunctionCodeStream = new System.IO.MemoryStream(cmdletContext.ConnectionFunctionCode);
                    request.ConnectionFunctionCode = _ConnectionFunctionCodeStream;
                }
                
                 // populate ConnectionFunctionConfig
                var requestConnectionFunctionConfigIsNull = true;
                request.ConnectionFunctionConfig = new Amazon.CloudFront.Model.FunctionConfig();
                System.String requestConnectionFunctionConfig_connectionFunctionConfig_Comment = null;
                if (cmdletContext.ConnectionFunctionConfig_Comment != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_Comment = cmdletContext.ConnectionFunctionConfig_Comment;
                }
                if (requestConnectionFunctionConfig_connectionFunctionConfig_Comment != null)
                {
                    request.ConnectionFunctionConfig.Comment = requestConnectionFunctionConfig_connectionFunctionConfig_Comment;
                    requestConnectionFunctionConfigIsNull = false;
                }
                Amazon.CloudFront.FunctionRuntime requestConnectionFunctionConfig_connectionFunctionConfig_Runtime = null;
                if (cmdletContext.ConnectionFunctionConfig_Runtime != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_Runtime = cmdletContext.ConnectionFunctionConfig_Runtime;
                }
                if (requestConnectionFunctionConfig_connectionFunctionConfig_Runtime != null)
                {
                    request.ConnectionFunctionConfig.Runtime = requestConnectionFunctionConfig_connectionFunctionConfig_Runtime;
                    requestConnectionFunctionConfigIsNull = false;
                }
                Amazon.CloudFront.Model.KeyValueStoreAssociations requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations = null;
                
                 // populate KeyValueStoreAssociations
                var requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociationsIsNull = true;
                requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations = new Amazon.CloudFront.Model.KeyValueStoreAssociations();
                List<Amazon.CloudFront.Model.KeyValueStoreAssociation> requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item = null;
                if (cmdletContext.KeyValueStoreAssociations_Item != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item = cmdletContext.KeyValueStoreAssociations_Item;
                }
                if (requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations.Items = requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item;
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociationsIsNull = false;
                }
                System.Int32? requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity = null;
                if (cmdletContext.KeyValueStoreAssociations_Quantity != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity = cmdletContext.KeyValueStoreAssociations_Quantity.Value;
                }
                if (requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity != null)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations.Quantity = requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity.Value;
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociationsIsNull = false;
                }
                 // determine if requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations should be set to null
                if (requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociationsIsNull)
                {
                    requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations = null;
                }
                if (requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations != null)
                {
                    request.ConnectionFunctionConfig.KeyValueStoreAssociations = requestConnectionFunctionConfig_connectionFunctionConfig_KeyValueStoreAssociations;
                    requestConnectionFunctionConfigIsNull = false;
                }
                 // determine if request.ConnectionFunctionConfig should be set to null
                if (requestConnectionFunctionConfigIsNull)
                {
                    request.ConnectionFunctionConfig = null;
                }
                if (cmdletContext.Id != null)
                {
                    request.Id = cmdletContext.Id;
                }
                if (cmdletContext.IfMatch != null)
                {
                    request.IfMatch = cmdletContext.IfMatch;
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
                if( _ConnectionFunctionCodeStream != null)
                {
                    _ConnectionFunctionCodeStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudFront.Model.UpdateConnectionFunctionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateConnectionFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateConnectionFunction");
            try
            {
                return client.UpdateConnectionFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] ConnectionFunctionCode { get; set; }
            public System.String ConnectionFunctionConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.KeyValueStoreAssociation> KeyValueStoreAssociations_Item { get; set; }
            public System.Int32? KeyValueStoreAssociations_Quantity { get; set; }
            public Amazon.CloudFront.FunctionRuntime ConnectionFunctionConfig_Runtime { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateConnectionFunctionResponse, UpdateCFConnectionFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectionFunctionSummary;
        }
        
    }
}
