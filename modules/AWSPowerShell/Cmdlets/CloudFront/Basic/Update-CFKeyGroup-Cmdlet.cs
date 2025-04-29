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
    /// Updates a key group.
    /// 
    ///  
    /// <para>
    /// When you update a key group, all the fields are updated with the values provided in
    /// the request. You cannot update some fields independent of others. To update a key
    /// group:
    /// </para><ol><li><para>
    /// Get the current key group with <c>GetKeyGroup</c> or <c>GetKeyGroupConfig</c>.
    /// </para></li><li><para>
    /// Locally modify the fields in the key group that you want to update. For example, add
    /// or remove public key IDs.
    /// </para></li><li><para>
    /// Call <c>UpdateKeyGroup</c> with the entire key group object, including the fields
    /// that you modified and those that you didn't.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Update", "CFKeyGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.KeyGroup")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateKeyGroup API operation.", Operation = new[] {"UpdateKeyGroup"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateKeyGroupResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.KeyGroup or Amazon.CloudFront.Model.UpdateKeyGroupResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.KeyGroup object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateKeyGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFKeyGroupCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KeyGroupConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the key group. The comment cannot be longer than 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyGroupConfig_Comment { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the key group that you are updating.</para>
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
        /// <para>The version of the key group that you are updating. The version is the key group's
        /// <c>ETag</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter KeyGroupConfig_Item
        /// <summary>
        /// <para>
        /// <para>A list of the identifiers of the public keys in the key group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("KeyGroupConfig_Items")]
        public System.String[] KeyGroupConfig_Item { get; set; }
        #endregion
        
        #region Parameter KeyGroupConfig_Name
        /// <summary>
        /// <para>
        /// <para>A name to identify the key group.</para>
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
        public System.String KeyGroupConfig_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateKeyGroupResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateKeyGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyGroup";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFKeyGroup (UpdateKeyGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateKeyGroupResponse, UpdateCFKeyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            context.KeyGroupConfig_Comment = this.KeyGroupConfig_Comment;
            if (this.KeyGroupConfig_Item != null)
            {
                context.KeyGroupConfig_Item = new List<System.String>(this.KeyGroupConfig_Item);
            }
            #if MODULAR
            if (this.KeyGroupConfig_Item == null && ParameterWasBound(nameof(this.KeyGroupConfig_Item)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyGroupConfig_Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyGroupConfig_Name = this.KeyGroupConfig_Name;
            #if MODULAR
            if (this.KeyGroupConfig_Name == null && ParameterWasBound(nameof(this.KeyGroupConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyGroupConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.UpdateKeyGroupRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
             // populate KeyGroupConfig
            var requestKeyGroupConfigIsNull = true;
            request.KeyGroupConfig = new Amazon.CloudFront.Model.KeyGroupConfig();
            System.String requestKeyGroupConfig_keyGroupConfig_Comment = null;
            if (cmdletContext.KeyGroupConfig_Comment != null)
            {
                requestKeyGroupConfig_keyGroupConfig_Comment = cmdletContext.KeyGroupConfig_Comment;
            }
            if (requestKeyGroupConfig_keyGroupConfig_Comment != null)
            {
                request.KeyGroupConfig.Comment = requestKeyGroupConfig_keyGroupConfig_Comment;
                requestKeyGroupConfigIsNull = false;
            }
            List<System.String> requestKeyGroupConfig_keyGroupConfig_Item = null;
            if (cmdletContext.KeyGroupConfig_Item != null)
            {
                requestKeyGroupConfig_keyGroupConfig_Item = cmdletContext.KeyGroupConfig_Item;
            }
            if (requestKeyGroupConfig_keyGroupConfig_Item != null)
            {
                request.KeyGroupConfig.Items = requestKeyGroupConfig_keyGroupConfig_Item;
                requestKeyGroupConfigIsNull = false;
            }
            System.String requestKeyGroupConfig_keyGroupConfig_Name = null;
            if (cmdletContext.KeyGroupConfig_Name != null)
            {
                requestKeyGroupConfig_keyGroupConfig_Name = cmdletContext.KeyGroupConfig_Name;
            }
            if (requestKeyGroupConfig_keyGroupConfig_Name != null)
            {
                request.KeyGroupConfig.Name = requestKeyGroupConfig_keyGroupConfig_Name;
                requestKeyGroupConfigIsNull = false;
            }
             // determine if request.KeyGroupConfig should be set to null
            if (requestKeyGroupConfigIsNull)
            {
                request.KeyGroupConfig = null;
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
        
        private Amazon.CloudFront.Model.UpdateKeyGroupResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateKeyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateKeyGroup");
            try
            {
                return client.UpdateKeyGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.String KeyGroupConfig_Comment { get; set; }
            public List<System.String> KeyGroupConfig_Item { get; set; }
            public System.String KeyGroupConfig_Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateKeyGroupResponse, UpdateCFKeyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyGroup;
        }
        
    }
}
