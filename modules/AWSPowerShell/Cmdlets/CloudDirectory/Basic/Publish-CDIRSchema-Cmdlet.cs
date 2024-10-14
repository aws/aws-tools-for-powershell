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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Publishes a development schema with a major version and a recommended minor version.
    /// </summary>
    [Cmdlet("Publish", "CDIRSchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cloud Directory PublishSchema API operation.", Operation = new[] {"PublishSchema"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.PublishSchemaResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudDirectory.Model.PublishSchemaResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudDirectory.Model.PublishSchemaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class PublishCDIRSchemaCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DevelopmentSchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the development schema. For
        /// more information, see <a>arns</a>.</para>
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
        public System.String DevelopmentSchemaArn { get; set; }
        #endregion
        
        #region Parameter MinorVersion
        /// <summary>
        /// <para>
        /// <para>The minor version under which the schema will be published. This parameter is recommended.
        /// Schemas have both a major and minor version associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MinorVersion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name under which the schema will be published. If this is not provided, the
        /// development schema is considered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The major version under which the schema will be published. Schemas have both a major
        /// and minor version associated with them.</para>
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
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PublishedSchemaArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.PublishSchemaResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.PublishSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PublishedSchemaArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DevelopmentSchemaArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DevelopmentSchemaArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DevelopmentSchemaArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DevelopmentSchemaArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-CDIRSchema (PublishSchema)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.PublishSchemaResponse, PublishCDIRSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DevelopmentSchemaArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DevelopmentSchemaArn = this.DevelopmentSchemaArn;
            #if MODULAR
            if (this.DevelopmentSchemaArn == null && ParameterWasBound(nameof(this.DevelopmentSchemaArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DevelopmentSchemaArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinorVersion = this.MinorVersion;
            context.Name = this.Name;
            context.Version = this.Version;
            #if MODULAR
            if (this.Version == null && ParameterWasBound(nameof(this.Version)))
            {
                WriteWarning("You are passing $null as a value for parameter Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudDirectory.Model.PublishSchemaRequest();
            
            if (cmdletContext.DevelopmentSchemaArn != null)
            {
                request.DevelopmentSchemaArn = cmdletContext.DevelopmentSchemaArn;
            }
            if (cmdletContext.MinorVersion != null)
            {
                request.MinorVersion = cmdletContext.MinorVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.CloudDirectory.Model.PublishSchemaResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.PublishSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "PublishSchema");
            try
            {
                #if DESKTOP
                return client.PublishSchema(request);
                #elif CORECLR
                return client.PublishSchemaAsync(request).GetAwaiter().GetResult();
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
            public System.String DevelopmentSchemaArn { get; set; }
            public System.String MinorVersion { get; set; }
            public System.String Name { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.PublishSchemaResponse, PublishCDIRSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PublishedSchemaArn;
        }
        
    }
}
