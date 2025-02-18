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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the properties of the specified Amazon WorkSpaces clients.
    /// </summary>
    [Cmdlet("Edit", "WKSClientProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyClientProperties API operation.", Operation = new[] {"ModifyClientProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSClientPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientProperties_LogUploadEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can upload diagnostic log files of Amazon WorkSpaces client
        /// directly to WorkSpaces to troubleshoot issues when using the WorkSpaces client. When
        /// enabled, the log files will be sent to WorkSpaces automatically and will be applied
        /// to all users in the specified directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.LogUploadEnum")]
        public Amazon.WorkSpaces.LogUploadEnum ClientProperties_LogUploadEnabled { get; set; }
        #endregion
        
        #region Parameter ClientProperties_ReconnectEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether users can cache their credentials on the Amazon WorkSpaces client.
        /// When enabled, users can choose to reconnect to their WorkSpaces without re-entering
        /// their credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ReconnectEnum")]
        public Amazon.WorkSpaces.ReconnectEnum ClientProperties_ReconnectEnabled { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource identifiers, in the form of directory IDs.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSClientProperty (ModifyClientProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse, EditWKSClientPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientProperties_LogUploadEnabled = this.ClientProperties_LogUploadEnabled;
            context.ClientProperties_ReconnectEnabled = this.ClientProperties_ReconnectEnabled;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.ModifyClientPropertiesRequest();
            
            
             // populate ClientProperties
            var requestClientPropertiesIsNull = true;
            request.ClientProperties = new Amazon.WorkSpaces.Model.ClientProperties();
            Amazon.WorkSpaces.LogUploadEnum requestClientProperties_clientProperties_LogUploadEnabled = null;
            if (cmdletContext.ClientProperties_LogUploadEnabled != null)
            {
                requestClientProperties_clientProperties_LogUploadEnabled = cmdletContext.ClientProperties_LogUploadEnabled;
            }
            if (requestClientProperties_clientProperties_LogUploadEnabled != null)
            {
                request.ClientProperties.LogUploadEnabled = requestClientProperties_clientProperties_LogUploadEnabled;
                requestClientPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.ReconnectEnum requestClientProperties_clientProperties_ReconnectEnabled = null;
            if (cmdletContext.ClientProperties_ReconnectEnabled != null)
            {
                requestClientProperties_clientProperties_ReconnectEnabled = cmdletContext.ClientProperties_ReconnectEnabled;
            }
            if (requestClientProperties_clientProperties_ReconnectEnabled != null)
            {
                request.ClientProperties.ReconnectEnabled = requestClientProperties_clientProperties_ReconnectEnabled;
                requestClientPropertiesIsNull = false;
            }
             // determine if request.ClientProperties should be set to null
            if (requestClientPropertiesIsNull)
            {
                request.ClientProperties = null;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyClientPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyClientProperties");
            try
            {
                return client.ModifyClientPropertiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.WorkSpaces.LogUploadEnum ClientProperties_LogUploadEnabled { get; set; }
            public Amazon.WorkSpaces.ReconnectEnum ClientProperties_ReconnectEnabled { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyClientPropertiesResponse, EditWKSClientPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
