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
    /// Creates an application.
    /// 
    ///  
    /// <para>
    /// Applications are an Amazon AppStream 2.0 resource that stores the details about how
    /// to launch applications on Elastic fleet streaming instances. An application consists
    /// of the launch details, icon, and display name. Applications are associated with an
    /// app block that contains the application binaries and other files. The applications
    /// assigned to an Elastic fleet are the applications users can launch. 
    /// </para><para>
    /// This is only supported for Elastic fleets.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Application")]
    [AWSCmdlet("Calls the Amazon AppStream CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Application or Amazon.AppStream.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Application object.",
        "The service call response (type Amazon.AppStream.Model.CreateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSApplicationCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AppBlockArn
        /// <summary>
        /// <para>
        /// <para>The app block ARN to which the application should be associated</para>
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
        public System.String AppBlockArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the application. This name is visible to users in the application
        /// catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceFamily
        /// <summary>
        /// <para>
        /// <para>The instance families the application supports. Valid values are GENERAL_PURPOSE and
        /// GRAPHICS_G4.</para>
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
        [Alias("InstanceFamilies")]
        public System.String[] InstanceFamily { get; set; }
        #endregion
        
        #region Parameter LaunchParameter
        /// <summary>
        /// <para>
        /// <para>The launch parameters of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchParameters")]
        public System.String LaunchParameter { get; set; }
        #endregion
        
        #region Parameter LaunchPath
        /// <summary>
        /// <para>
        /// <para>The launch path of the application.</para>
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
        public System.String LaunchPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application. This name is visible to users when display name is not
        /// specified.</para>
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
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platforms the application supports. WINDOWS_SERVER_2019 and AMAZON_LINUX2 are
        /// supported for Elastic fleets.</para>
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
        [Alias("Platforms")]
        public System.String[] Platform { get; set; }
        #endregion
        
        #region Parameter IconS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
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
        public System.String IconS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter IconS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para>
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
        public System.String IconS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkingDirectory
        /// <summary>
        /// <para>
        /// <para>The working directory of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkingDirectory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Application'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Application";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateApplicationResponse, NewAPSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppBlockArn = this.AppBlockArn;
            #if MODULAR
            if (this.AppBlockArn == null && ParameterWasBound(nameof(this.AppBlockArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBlockArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.IconS3Location_S3Bucket = this.IconS3Location_S3Bucket;
            #if MODULAR
            if (this.IconS3Location_S3Bucket == null && ParameterWasBound(nameof(this.IconS3Location_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter IconS3Location_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IconS3Location_S3Key = this.IconS3Location_S3Key;
            #if MODULAR
            if (this.IconS3Location_S3Key == null && ParameterWasBound(nameof(this.IconS3Location_S3Key)))
            {
                WriteWarning("You are passing $null as a value for parameter IconS3Location_S3Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceFamily != null)
            {
                context.InstanceFamily = new List<System.String>(this.InstanceFamily);
            }
            #if MODULAR
            if (this.InstanceFamily == null && ParameterWasBound(nameof(this.InstanceFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchParameter = this.LaunchParameter;
            context.LaunchPath = this.LaunchPath;
            #if MODULAR
            if (this.LaunchPath == null && ParameterWasBound(nameof(this.LaunchPath)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Platform != null)
            {
                context.Platform = new List<System.String>(this.Platform);
            }
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.WorkingDirectory = this.WorkingDirectory;
            
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
            var request = new Amazon.AppStream.Model.CreateApplicationRequest();
            
            if (cmdletContext.AppBlockArn != null)
            {
                request.AppBlockArn = cmdletContext.AppBlockArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate IconS3Location
            var requestIconS3LocationIsNull = true;
            request.IconS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestIconS3Location_iconS3Location_S3Bucket = null;
            if (cmdletContext.IconS3Location_S3Bucket != null)
            {
                requestIconS3Location_iconS3Location_S3Bucket = cmdletContext.IconS3Location_S3Bucket;
            }
            if (requestIconS3Location_iconS3Location_S3Bucket != null)
            {
                request.IconS3Location.S3Bucket = requestIconS3Location_iconS3Location_S3Bucket;
                requestIconS3LocationIsNull = false;
            }
            System.String requestIconS3Location_iconS3Location_S3Key = null;
            if (cmdletContext.IconS3Location_S3Key != null)
            {
                requestIconS3Location_iconS3Location_S3Key = cmdletContext.IconS3Location_S3Key;
            }
            if (requestIconS3Location_iconS3Location_S3Key != null)
            {
                request.IconS3Location.S3Key = requestIconS3Location_iconS3Location_S3Key;
                requestIconS3LocationIsNull = false;
            }
             // determine if request.IconS3Location should be set to null
            if (requestIconS3LocationIsNull)
            {
                request.IconS3Location = null;
            }
            if (cmdletContext.InstanceFamily != null)
            {
                request.InstanceFamilies = cmdletContext.InstanceFamily;
            }
            if (cmdletContext.LaunchParameter != null)
            {
                request.LaunchParameters = cmdletContext.LaunchParameter;
            }
            if (cmdletContext.LaunchPath != null)
            {
                request.LaunchPath = cmdletContext.LaunchPath;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platforms = cmdletContext.Platform;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkingDirectory != null)
            {
                request.WorkingDirectory = cmdletContext.WorkingDirectory;
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
        
        private Amazon.AppStream.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppBlockArn { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String IconS3Location_S3Bucket { get; set; }
            public System.String IconS3Location_S3Key { get; set; }
            public List<System.String> InstanceFamily { get; set; }
            public System.String LaunchParameter { get; set; }
            public System.String LaunchPath { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Platform { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkingDirectory { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateApplicationResponse, NewAPSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Application;
        }
        
    }
}
