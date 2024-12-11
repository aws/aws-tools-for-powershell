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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Creates a custom plugin using the specified properties.
    /// </summary>
    [Cmdlet("New", "MSKCCustomPlugin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KafkaConnect.Model.CreateCustomPluginResponse")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect CreateCustomPlugin API operation.", Operation = new[] {"CreateCustomPlugin"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.CreateCustomPluginResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.CreateCustomPluginResponse",
        "This cmdlet returns an Amazon.KafkaConnect.Model.CreateCustomPluginResponse object containing multiple properties."
    )]
    public partial class NewMSKCCustomPluginCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Location_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an S3 bucket.</para>
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
        [Alias("Location_S3Location_BucketArn")]
        public System.String S3Location_BucketArn { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The type of the plugin file.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KafkaConnect.CustomPluginContentType")]
        public Amazon.KafkaConnect.CustomPluginContentType ContentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A summary description of the custom plugin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3Location_FileKey
        /// <summary>
        /// <para>
        /// <para>The file key for an object in an S3 bucket.</para>
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
        [Alias("Location_S3Location_FileKey")]
        public System.String S3Location_FileKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the custom plugin.</para>
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
        
        #region Parameter S3Location_ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of an object in an S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Location_S3Location_ObjectVersion")]
        public System.String S3Location_ObjectVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags you want to attach to the custom plugin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.CreateCustomPluginResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.CreateCustomPluginResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKCCustomPlugin (CreateCustomPlugin)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.CreateCustomPluginResponse, NewMSKCCustomPluginCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContentType = this.ContentType;
            #if MODULAR
            if (this.ContentType == null && ParameterWasBound(nameof(this.ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.S3Location_BucketArn = this.S3Location_BucketArn;
            #if MODULAR
            if (this.S3Location_BucketArn == null && ParameterWasBound(nameof(this.S3Location_BucketArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Location_BucketArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Location_FileKey = this.S3Location_FileKey;
            #if MODULAR
            if (this.S3Location_FileKey == null && ParameterWasBound(nameof(this.S3Location_FileKey)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Location_FileKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Location_ObjectVersion = this.S3Location_ObjectVersion;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.KafkaConnect.Model.CreateCustomPluginRequest();
            
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Location
            var requestLocationIsNull = true;
            request.Location = new Amazon.KafkaConnect.Model.CustomPluginLocation();
            Amazon.KafkaConnect.Model.S3Location requestLocation_location_S3Location = null;
            
             // populate S3Location
            var requestLocation_location_S3LocationIsNull = true;
            requestLocation_location_S3Location = new Amazon.KafkaConnect.Model.S3Location();
            System.String requestLocation_location_S3Location_s3Location_BucketArn = null;
            if (cmdletContext.S3Location_BucketArn != null)
            {
                requestLocation_location_S3Location_s3Location_BucketArn = cmdletContext.S3Location_BucketArn;
            }
            if (requestLocation_location_S3Location_s3Location_BucketArn != null)
            {
                requestLocation_location_S3Location.BucketArn = requestLocation_location_S3Location_s3Location_BucketArn;
                requestLocation_location_S3LocationIsNull = false;
            }
            System.String requestLocation_location_S3Location_s3Location_FileKey = null;
            if (cmdletContext.S3Location_FileKey != null)
            {
                requestLocation_location_S3Location_s3Location_FileKey = cmdletContext.S3Location_FileKey;
            }
            if (requestLocation_location_S3Location_s3Location_FileKey != null)
            {
                requestLocation_location_S3Location.FileKey = requestLocation_location_S3Location_s3Location_FileKey;
                requestLocation_location_S3LocationIsNull = false;
            }
            System.String requestLocation_location_S3Location_s3Location_ObjectVersion = null;
            if (cmdletContext.S3Location_ObjectVersion != null)
            {
                requestLocation_location_S3Location_s3Location_ObjectVersion = cmdletContext.S3Location_ObjectVersion;
            }
            if (requestLocation_location_S3Location_s3Location_ObjectVersion != null)
            {
                requestLocation_location_S3Location.ObjectVersion = requestLocation_location_S3Location_s3Location_ObjectVersion;
                requestLocation_location_S3LocationIsNull = false;
            }
             // determine if requestLocation_location_S3Location should be set to null
            if (requestLocation_location_S3LocationIsNull)
            {
                requestLocation_location_S3Location = null;
            }
            if (requestLocation_location_S3Location != null)
            {
                request.Location.S3Location = requestLocation_location_S3Location;
                requestLocationIsNull = false;
            }
             // determine if request.Location should be set to null
            if (requestLocationIsNull)
            {
                request.Location = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.KafkaConnect.Model.CreateCustomPluginResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.CreateCustomPluginRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "CreateCustomPlugin");
            try
            {
                #if DESKTOP
                return client.CreateCustomPlugin(request);
                #elif CORECLR
                return client.CreateCustomPluginAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KafkaConnect.CustomPluginContentType ContentType { get; set; }
            public System.String Description { get; set; }
            public System.String S3Location_BucketArn { get; set; }
            public System.String S3Location_FileKey { get; set; }
            public System.String S3Location_ObjectVersion { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.CreateCustomPluginResponse, NewMSKCCustomPluginCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
