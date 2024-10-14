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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a new image with the latest Windows operating system updates, driver updates,
    /// and AppStream 2.0 agent software.
    /// 
    ///  
    /// <para>
    /// For more information, see the "Update an Image by Using Managed AppStream 2.0 Image
    /// Updates" section in <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/administer-images.html">Administer
    /// Your AppStream 2.0 Images</a>, in the <i>Amazon AppStream 2.0 Administration Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APSUpdatedImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.CreateUpdatedImageResponse")]
    [AWSCmdlet("Calls the Amazon AppStream CreateUpdatedImage API operation.", Operation = new[] {"CreateUpdatedImage"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateUpdatedImageResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.CreateUpdatedImageResponse",
        "This cmdlet returns an Amazon.AppStream.Model.CreateUpdatedImageResponse object containing multiple properties."
    )]
    public partial class NewAPSUpdatedImageCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Indicates whether to display the status of image update availability before AppStream
        /// 2.0 initiates the process of creating a new updated image. If this value is set to
        /// <c>true</c>, AppStream 2.0 displays whether image updates are available. If this value
        /// is set to <c>false</c>, AppStream 2.0 initiates the process of creating a new updated
        /// image without displaying whether image updates are available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ExistingImageName
        /// <summary>
        /// <para>
        /// <para>The name of the image to update.</para>
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
        public System.String ExistingImageName { get; set; }
        #endregion
        
        #region Parameter NewImageDescription
        /// <summary>
        /// <para>
        /// <para>The description to display for the new image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewImageDescription { get; set; }
        #endregion
        
        #region Parameter NewImageDisplayName
        /// <summary>
        /// <para>
        /// <para>The name to display for the new image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewImageDisplayName { get; set; }
        #endregion
        
        #region Parameter NewImageName
        /// <summary>
        /// <para>
        /// <para>The name of the new image. The name must be unique within the AWS account and Region.</para>
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
        public System.String NewImageName { get; set; }
        #endregion
        
        #region Parameter NewImageTag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the new image. A tag is a key-value pair, and the value
        /// is optional. For example, Environment=Test. If you do not specify a value, Environment=.
        /// </para><para>Generally allowed characters are: letters, numbers, and spaces representable in UTF-8,
        /// and the following special characters: </para><para>_ . : / = + \ - @</para><para>If you do not specify a value, the value is set to an empty string.</para><para>For more information about tags, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewImageTags")]
        public System.Collections.Hashtable NewImageTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateUpdatedImageResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateUpdatedImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NewImageName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NewImageName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NewImageName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExistingImageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSUpdatedImage (CreateUpdatedImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateUpdatedImageResponse, NewAPSUpdatedImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NewImageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.ExistingImageName = this.ExistingImageName;
            #if MODULAR
            if (this.ExistingImageName == null && ParameterWasBound(nameof(this.ExistingImageName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExistingImageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewImageDescription = this.NewImageDescription;
            context.NewImageDisplayName = this.NewImageDisplayName;
            context.NewImageName = this.NewImageName;
            #if MODULAR
            if (this.NewImageName == null && ParameterWasBound(nameof(this.NewImageName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewImageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NewImageTag != null)
            {
                context.NewImageTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewImageTag.Keys)
                {
                    context.NewImageTag.Add((String)hashKey, (System.String)(this.NewImageTag[hashKey]));
                }
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
            var request = new Amazon.AppStream.Model.CreateUpdatedImageRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ExistingImageName != null)
            {
                request.ExistingImageName = cmdletContext.ExistingImageName;
            }
            if (cmdletContext.NewImageDescription != null)
            {
                request.NewImageDescription = cmdletContext.NewImageDescription;
            }
            if (cmdletContext.NewImageDisplayName != null)
            {
                request.NewImageDisplayName = cmdletContext.NewImageDisplayName;
            }
            if (cmdletContext.NewImageName != null)
            {
                request.NewImageName = cmdletContext.NewImageName;
            }
            if (cmdletContext.NewImageTag != null)
            {
                request.NewImageTags = cmdletContext.NewImageTag;
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
        
        private Amazon.AppStream.Model.CreateUpdatedImageResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateUpdatedImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateUpdatedImage");
            try
            {
                #if DESKTOP
                return client.CreateUpdatedImage(request);
                #elif CORECLR
                return client.CreateUpdatedImageAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String ExistingImageName { get; set; }
            public System.String NewImageDescription { get; set; }
            public System.String NewImageDisplayName { get; set; }
            public System.String NewImageName { get; set; }
            public Dictionary<System.String, System.String> NewImageTag { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateUpdatedImageResponse, NewAPSUpdatedImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
