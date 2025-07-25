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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Creates a new virtual MFA device for the Amazon Web Services account. After creating
    /// the virtual MFA, use <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_EnableMFADevice.html">EnableMFADevice</a>
    /// to attach the MFA device to an IAM user. For more information about creating and working
    /// with virtual MFA devices, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_VirtualMFA.html">Using
    /// a virtual MFA device</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para>
    /// For information about the maximum number of MFA devices you can create, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_iam-quotas.html">IAM
    /// and STS quotas</a> in the <i>IAM User Guide</i>.
    /// </para><important><para>
    /// The seed information contained in the QR code and the Base32 string should be treated
    /// like any other secret access information. In other words, protect the seed information
    /// as you would your Amazon Web Services access keys or your passwords. After you provision
    /// your virtual device, you should ensure that the information is destroyed following
    /// secure procedures.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IAMVirtualMFADevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.VirtualMFADevice")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateVirtualMFADevice API operation.", Operation = new[] {"CreateVirtualMFADevice"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.VirtualMFADevice or Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.VirtualMFADevice object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMVirtualMFADeviceCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para> The path for the virtual MFA device. For more information about paths, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">IAM
        /// identifiers</a> in the <i>IAM User Guide</i>.</para><para>This parameter is optional. If it is not included, it defaults to a slash (/).</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of either a forward slash (/) by itself
        /// or a string that must begin and end with forward slashes. In addition, it can contain
        /// any ASCII character from the ! (<c>\u0021</c>) through the DEL character (<c>\u007F</c>),
        /// including most punctuation characters, digits, and upper and lowercased letters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the new IAM virtual MFA device. Each tag
        /// consists of a key name and an associated value. For more information about tagging,
        /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_tags.html">Tagging
        /// IAM resources</a> in the <i>IAM User Guide</i>.</para><note><para>If any one of the tags is invalid or if you exceed the allowed maximum number of tags,
        /// then the entire request fails and the resource is not created.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IdentityManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VirtualMFADeviceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual MFA device, which must be unique. Use with path to uniquely
        /// identify a virtual MFA device.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VirtualMFADeviceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualMFADevice'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualMFADevice";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualMFADeviceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMVirtualMFADevice (CreateVirtualMFADevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse, NewIAMVirtualMFADeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Path = this.Path;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
            }
            context.VirtualMFADeviceName = this.VirtualMFADeviceName;
            #if MODULAR
            if (this.VirtualMFADeviceName == null && ParameterWasBound(nameof(this.VirtualMFADeviceName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualMFADeviceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.CreateVirtualMFADeviceRequest();
            
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VirtualMFADeviceName != null)
            {
                request.VirtualMFADeviceName = cmdletContext.VirtualMFADeviceName;
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
        
        private Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateVirtualMFADeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateVirtualMFADevice");
            try
            {
                return client.CreateVirtualMFADeviceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Path { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tag { get; set; }
            public System.String VirtualMFADeviceName { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateVirtualMFADeviceResponse, NewIAMVirtualMFADeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualMFADevice;
        }
        
    }
}
