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
using Amazon.EndUserMessaging;
using Amazon.EndUserMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EUM
{
    /// <summary>
    /// Updates the value, description, or category of an existing brand profile attribute.
    /// </summary>
    [Cmdlet("Update", "EUMBrandProfileAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging UpdateBrandProfileAttribute API operation.", Operation = new[] {"UpdateBrandProfileAttribute"}, SelectReturnType = typeof(Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse))]
    [AWSCmdletOutput("Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse",
        "This cmdlet returns an Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse object containing multiple properties."
    )]
    public partial class UpdateEUMBrandProfileAttributeCmdlet : AmazonEndUserMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachmentBody
        /// <summary>
        /// <para>
        /// <para>The binary content for an attribute of type IMAGE or DOCUMENT. The content is base64-encoded
        /// when it is sent over the wire.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] AttachmentBody { get; set; }
        #endregion
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the brand profile attribute. The name is unique within a brand profile.</para>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter AttributeValue
        /// <summary>
        /// <para>
        /// <para>The text value of the attribute. This value applies to attributes of type TEXT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttributeValue { get; set; }
        #endregion
        
        #region Parameter BrandProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the brand profile. You can specify either the bare ID or
        /// the full Amazon Resource Name (ARN).</para>
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
        public System.String BrandProfileId { get; set; }
        #endregion
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>The category of the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse).
        /// Specifying the name of a property of type Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.BrandProfileId),
                nameof(this.AttributeName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters, new System.Collections.Generic.HashSet<string> { nameof(this.AttributeName) });
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EUMBrandProfileAttribute (UpdateBrandProfileAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse, UpdateEUMBrandProfileAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentBody = this.AttachmentBody;
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeValue = this.AttributeValue;
            context.BrandProfileId = this.BrandProfileId;
            #if MODULAR
            if (this.BrandProfileId == null && ParameterWasBound(nameof(this.BrandProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter BrandProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Category = this.Category;
            context.Description = this.Description;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _AttachmentBodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeRequest();
                
                if (cmdletContext.AttachmentBody != null)
                {
                    _AttachmentBodyStream = new System.IO.MemoryStream(cmdletContext.AttachmentBody);
                    request.AttachmentBody = _AttachmentBodyStream;
                }
                if (cmdletContext.AttributeName != null)
                {
                    request.AttributeName = cmdletContext.AttributeName;
                }
                if (cmdletContext.AttributeValue != null)
                {
                    request.AttributeValue = cmdletContext.AttributeValue;
                }
                if (cmdletContext.BrandProfileId != null)
                {
                    request.BrandProfileId = cmdletContext.BrandProfileId;
                }
                if (cmdletContext.Category != null)
                {
                    request.Category = cmdletContext.Category;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
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
                if( _AttachmentBodyStream != null)
                {
                    _AttachmentBodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse CallAWSServiceOperation(IAmazonEndUserMessaging client, Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging", "UpdateBrandProfileAttribute");
            try
            {
                return client.UpdateBrandProfileAttributeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] AttachmentBody { get; set; }
            public System.String AttributeName { get; set; }
            public System.String AttributeValue { get; set; }
            public System.String BrandProfileId { get; set; }
            public System.String Category { get; set; }
            public System.String Description { get; set; }
            public System.Func<Amazon.EndUserMessaging.Model.UpdateBrandProfileAttributeResponse, UpdateEUMBrandProfileAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
