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
using Amazon.AppTest;
using Amazon.AppTest.Model;

namespace Amazon.PowerShell.Cmdlets.AT
{
    /// <summary>
    /// Updates a test configuration.
    /// </summary>
    [Cmdlet("Update", "ATTestConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppTest.Model.UpdateTestConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Mainframe Modernization Application Testing UpdateTestConfiguration API operation.", Operation = new[] {"UpdateTestConfiguration"}, SelectReturnType = typeof(Amazon.AppTest.Model.UpdateTestConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppTest.Model.UpdateTestConfigurationResponse",
        "This cmdlet returns an Amazon.AppTest.Model.UpdateTestConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateATTestConfigurationCmdlet : AmazonAppTestClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the test configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ServiceSettings_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key ID of the service settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceSettings_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Property
        /// <summary>
        /// <para>
        /// <para>The properties of the test configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Properties")]
        public System.Collections.Hashtable Property { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The resources of the test configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public Amazon.AppTest.Model.Resource[] Resource { get; set; }
        #endregion
        
        #region Parameter TestConfigurationId
        /// <summary>
        /// <para>
        /// <para>The test configuration ID of the test configuration.</para>
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
        public System.String TestConfigurationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppTest.Model.UpdateTestConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppTest.Model.UpdateTestConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TestConfigurationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TestConfigurationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TestConfigurationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestConfigurationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ATTestConfiguration (UpdateTestConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppTest.Model.UpdateTestConfigurationResponse, UpdateATTestConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TestConfigurationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.Property != null)
            {
                context.Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Property.Keys)
                {
                    context.Property.Add((String)hashKey, (System.String)(this.Property[hashKey]));
                }
            }
            if (this.Resource != null)
            {
                context.Resource = new List<Amazon.AppTest.Model.Resource>(this.Resource);
            }
            context.ServiceSettings_KmsKeyId = this.ServiceSettings_KmsKeyId;
            context.TestConfigurationId = this.TestConfigurationId;
            #if MODULAR
            if (this.TestConfigurationId == null && ParameterWasBound(nameof(this.TestConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppTest.Model.UpdateTestConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Property != null)
            {
                request.Properties = cmdletContext.Property;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            
             // populate ServiceSettings
            var requestServiceSettingsIsNull = true;
            request.ServiceSettings = new Amazon.AppTest.Model.ServiceSettings();
            System.String requestServiceSettings_serviceSettings_KmsKeyId = null;
            if (cmdletContext.ServiceSettings_KmsKeyId != null)
            {
                requestServiceSettings_serviceSettings_KmsKeyId = cmdletContext.ServiceSettings_KmsKeyId;
            }
            if (requestServiceSettings_serviceSettings_KmsKeyId != null)
            {
                request.ServiceSettings.KmsKeyId = requestServiceSettings_serviceSettings_KmsKeyId;
                requestServiceSettingsIsNull = false;
            }
             // determine if request.ServiceSettings should be set to null
            if (requestServiceSettingsIsNull)
            {
                request.ServiceSettings = null;
            }
            if (cmdletContext.TestConfigurationId != null)
            {
                request.TestConfigurationId = cmdletContext.TestConfigurationId;
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
        
        private Amazon.AppTest.Model.UpdateTestConfigurationResponse CallAWSServiceOperation(IAmazonAppTest client, Amazon.AppTest.Model.UpdateTestConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mainframe Modernization Application Testing", "UpdateTestConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateTestConfiguration(request);
                #elif CORECLR
                return client.UpdateTestConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Property { get; set; }
            public List<Amazon.AppTest.Model.Resource> Resource { get; set; }
            public System.String ServiceSettings_KmsKeyId { get; set; }
            public System.String TestConfigurationId { get; set; }
            public System.Func<Amazon.AppTest.Model.UpdateTestConfigurationResponse, UpdateATTestConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
