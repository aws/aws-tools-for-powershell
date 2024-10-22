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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates a key group that you can use with <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PrivateContent.html">CloudFront
    /// signed URLs and signed cookies</a>.
    /// 
    ///  
    /// <para>
    /// To create a key group, you must specify at least one public key for the key group.
    /// After you create a key group, you can reference it from one or more cache behaviors.
    /// When you reference a key group in a cache behavior, CloudFront requires signed URLs
    /// or signed cookies for all requests that match the cache behavior. The URLs or cookies
    /// must be signed with a private key whose corresponding public key is in the key group.
    /// The signed URL or cookie contains information about which public key CloudFront should
    /// use to verify the signature. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PrivateContent.html">Serving
    /// private content</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFKeyGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateKeyGroupResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateKeyGroup API operation.", Operation = new[] {"CreateKeyGroup"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateKeyGroupResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateKeyGroupResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateKeyGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFKeyGroupCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyGroupConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the key group. The comment cannot be longer than 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyGroupConfig_Comment { get; set; }
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyGroupConfig_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateKeyGroupResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateKeyGroupResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyGroupConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFKeyGroup (CreateKeyGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateKeyGroupResponse, NewCFKeyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.CloudFront.Model.CreateKeyGroupRequest();
            
            
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
        
        private Amazon.CloudFront.Model.CreateKeyGroupResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateKeyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateKeyGroup");
            try
            {
                #if DESKTOP
                return client.CreateKeyGroup(request);
                #elif CORECLR
                return client.CreateKeyGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyGroupConfig_Comment { get; set; }
            public List<System.String> KeyGroupConfig_Item { get; set; }
            public System.String KeyGroupConfig_Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateKeyGroupResponse, NewCFKeyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
