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

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a CloudFront function.
    /// 
    ///  
    /// <para>
    /// You can update a function's code or the comment that describes the function. You cannot
    /// update a function's name.
    /// </para><para>
    /// To update a function, you provide the function's name and version (<c>ETag</c> value)
    /// along with the updated function code. To get the name and version, you can use <c>ListFunctions</c>
    /// and <c>DescribeFunction</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.FunctionSummary")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateFunction API operation.", Operation = new[] {"UpdateFunction"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateFunctionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.FunctionSummary or Amazon.CloudFront.Model.UpdateFunctionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.FunctionSummary object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateFunctionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFFunctionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FunctionConfig_Comment
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
        public System.String FunctionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter FunctionCode
        /// <summary>
        /// <para>
        /// <para>The function code. For more information about writing a CloudFront function, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/writing-function-code.html">Writing
        /// function code for CloudFront Functions</a> in the <i>Amazon CloudFront Developer Guide</i>.</para>
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
        public byte[] FunctionCode { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current version (<c>ETag</c> value) of the function that you are updating, which
        /// you can get using <c>DescribeFunction</c>.</para>
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
        /// <para>The items of the key value store association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionConfig_KeyValueStoreAssociations_Items")]
        public Amazon.CloudFront.Model.KeyValueStoreAssociation[] KeyValueStoreAssociations_Item { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the function that you are updating.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter KeyValueStoreAssociations_Quantity
        /// <summary>
        /// <para>
        /// <para>The quantity of key value store associations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionConfig_KeyValueStoreAssociations_Quantity")]
        public System.Int32? KeyValueStoreAssociations_Quantity { get; set; }
        #endregion
        
        #region Parameter FunctionConfig_Runtime
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
        public Amazon.CloudFront.FunctionRuntime FunctionConfig_Runtime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FunctionSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateFunctionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FunctionSummary";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFFunction (UpdateFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateFunctionResponse, UpdateCFFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FunctionCode = this.FunctionCode;
            #if MODULAR
            if (this.FunctionCode == null && ParameterWasBound(nameof(this.FunctionCode)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FunctionConfig_Comment = this.FunctionConfig_Comment;
            #if MODULAR
            if (this.FunctionConfig_Comment == null && ParameterWasBound(nameof(this.FunctionConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.KeyValueStoreAssociations_Item != null)
            {
                context.KeyValueStoreAssociations_Item = new List<Amazon.CloudFront.Model.KeyValueStoreAssociation>(this.KeyValueStoreAssociations_Item);
            }
            context.KeyValueStoreAssociations_Quantity = this.KeyValueStoreAssociations_Quantity;
            context.FunctionConfig_Runtime = this.FunctionConfig_Runtime;
            #if MODULAR
            if (this.FunctionConfig_Runtime == null && ParameterWasBound(nameof(this.FunctionConfig_Runtime)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionConfig_Runtime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            #if MODULAR
            if (this.IfMatch == null && ParameterWasBound(nameof(this.IfMatch)))
            {
                WriteWarning("You are passing $null as a value for parameter IfMatch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _FunctionCodeStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CloudFront.Model.UpdateFunctionRequest();
                
                if (cmdletContext.FunctionCode != null)
                {
                    _FunctionCodeStream = new System.IO.MemoryStream(cmdletContext.FunctionCode);
                    request.FunctionCode = _FunctionCodeStream;
                }
                
                 // populate FunctionConfig
                var requestFunctionConfigIsNull = true;
                request.FunctionConfig = new Amazon.CloudFront.Model.FunctionConfig();
                System.String requestFunctionConfig_functionConfig_Comment = null;
                if (cmdletContext.FunctionConfig_Comment != null)
                {
                    requestFunctionConfig_functionConfig_Comment = cmdletContext.FunctionConfig_Comment;
                }
                if (requestFunctionConfig_functionConfig_Comment != null)
                {
                    request.FunctionConfig.Comment = requestFunctionConfig_functionConfig_Comment;
                    requestFunctionConfigIsNull = false;
                }
                Amazon.CloudFront.FunctionRuntime requestFunctionConfig_functionConfig_Runtime = null;
                if (cmdletContext.FunctionConfig_Runtime != null)
                {
                    requestFunctionConfig_functionConfig_Runtime = cmdletContext.FunctionConfig_Runtime;
                }
                if (requestFunctionConfig_functionConfig_Runtime != null)
                {
                    request.FunctionConfig.Runtime = requestFunctionConfig_functionConfig_Runtime;
                    requestFunctionConfigIsNull = false;
                }
                Amazon.CloudFront.Model.KeyValueStoreAssociations requestFunctionConfig_functionConfig_KeyValueStoreAssociations = null;
                
                 // populate KeyValueStoreAssociations
                var requestFunctionConfig_functionConfig_KeyValueStoreAssociationsIsNull = true;
                requestFunctionConfig_functionConfig_KeyValueStoreAssociations = new Amazon.CloudFront.Model.KeyValueStoreAssociations();
                List<Amazon.CloudFront.Model.KeyValueStoreAssociation> requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item = null;
                if (cmdletContext.KeyValueStoreAssociations_Item != null)
                {
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item = cmdletContext.KeyValueStoreAssociations_Item;
                }
                if (requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item != null)
                {
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociations.Items = requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Item;
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociationsIsNull = false;
                }
                System.Int32? requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity = null;
                if (cmdletContext.KeyValueStoreAssociations_Quantity != null)
                {
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity = cmdletContext.KeyValueStoreAssociations_Quantity.Value;
                }
                if (requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity != null)
                {
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociations.Quantity = requestFunctionConfig_functionConfig_KeyValueStoreAssociations_keyValueStoreAssociations_Quantity.Value;
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociationsIsNull = false;
                }
                 // determine if requestFunctionConfig_functionConfig_KeyValueStoreAssociations should be set to null
                if (requestFunctionConfig_functionConfig_KeyValueStoreAssociationsIsNull)
                {
                    requestFunctionConfig_functionConfig_KeyValueStoreAssociations = null;
                }
                if (requestFunctionConfig_functionConfig_KeyValueStoreAssociations != null)
                {
                    request.FunctionConfig.KeyValueStoreAssociations = requestFunctionConfig_functionConfig_KeyValueStoreAssociations;
                    requestFunctionConfigIsNull = false;
                }
                 // determine if request.FunctionConfig should be set to null
                if (requestFunctionConfigIsNull)
                {
                    request.FunctionConfig = null;
                }
                if (cmdletContext.IfMatch != null)
                {
                    request.IfMatch = cmdletContext.IfMatch;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
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
                if( _FunctionCodeStream != null)
                {
                    _FunctionCodeStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudFront.Model.UpdateFunctionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateFunction");
            try
            {
                return client.UpdateFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] FunctionCode { get; set; }
            public System.String FunctionConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.KeyValueStoreAssociation> KeyValueStoreAssociations_Item { get; set; }
            public System.Int32? KeyValueStoreAssociations_Quantity { get; set; }
            public Amazon.CloudFront.FunctionRuntime FunctionConfig_Runtime { get; set; }
            public System.String IfMatch { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateFunctionResponse, UpdateCFFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FunctionSummary;
        }
        
    }
}
