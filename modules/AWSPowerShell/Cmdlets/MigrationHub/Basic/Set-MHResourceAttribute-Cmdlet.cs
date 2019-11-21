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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Provides identifying details of the resource being migrated so that it can be associated
    /// in the Application Discovery Service (ADS)'s repository. This association occurs asynchronously
    /// after <code>PutResourceAttributes</code> returns.
    /// 
    ///  <important><ul><li><para>
    /// Keep in mind that subsequent calls to PutResourceAttributes will override previously
    /// stored attributes. For example, if it is first called with a MAC address, but later,
    /// it is desired to <i>add</i> an IP address, it will then be required to call it with
    /// <i>both</i> the IP and MAC addresses to prevent overiding the MAC address.
    /// </para></li><li><para>
    /// Note the instructions regarding the special use case of the <a href="https://docs.aws.amazon.com/migrationhub/latest/ug/API_PutResourceAttributes.html#migrationhub-PutResourceAttributes-request-ResourceAttributeList"><code>ResourceAttributeList</code></a> parameter when specifying any "VM" related
    /// value. 
    /// </para></li></ul></important><note><para>
    /// Because this is an asynchronous call, it will always return 200, whether an association
    /// occurs or not. To confirm if an association was found based on the provided details,
    /// call <code>ListDiscoveredResources</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "MHResourceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Migration Hub PutResourceAttributes API operation.", Operation = new[] {"PutResourceAttributes"}, SelectReturnType = typeof(Amazon.MigrationHub.Model.PutResourceAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHub.Model.PutResourceAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHub.Model.PutResourceAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetMHResourceAttributeCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional boolean flag to indicate whether any effect should take place. Used to test
        /// if the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MigrationTaskName
        /// <summary>
        /// <para>
        /// <para>Unique identifier that references the migration task.</para>
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
        public System.String MigrationTaskName { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStream
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. </para>
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
        public System.String ProgressUpdateStream { get; set; }
        #endregion
        
        #region Parameter ResourceAttributeList
        /// <summary>
        /// <para>
        /// <para>Information about the resource that is being migrated. This data will be used to map
        /// the task to a resource in the Application Discovery Service (ADS)'s repository.</para><note><para>Takes the object array of <code>ResourceAttribute</code> where the <code>Type</code>
        /// field is reserved for the following values: <code>IPV4_ADDRESS | IPV6_ADDRESS | MAC_ADDRESS
        /// | FQDN | VM_MANAGER_ID | VM_MANAGED_OBJECT_REFERENCE | VM_NAME | VM_PATH | BIOS_ID
        /// | MOTHERBOARD_SERIAL_NUMBER</code> where the identifying value can be a string up
        /// to 256 characters.</para></note><important><ul><li><para>If any "VM" related value is set for a <code>ResourceAttribute</code> object, it is
        /// required that <code>VM_MANAGER_ID</code>, as a minimum, is always set. If <code>VM_MANAGER_ID</code>
        /// is not set, then all "VM" fields will be discarded and "VM" fields will not be used
        /// for matching the migration task to a server in Application Discovery Service (ADS)'s
        /// repository. See the <a href="https://docs.aws.amazon.com/migrationhub/latest/ug/API_PutResourceAttributes.html#API_PutResourceAttributes_Examples">Example</a>
        /// section below for a use case of specifying "VM" related values.</para></li><li><para> If a server you are trying to match has multiple IP or MAC addresses, you should
        /// provide as many as you know in separate type/value pairs passed to the <code>ResourceAttributeList</code>
        /// parameter to maximize the chances of matching.</para></li></ul></important>
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
        public Amazon.MigrationHub.Model.ResourceAttribute[] ResourceAttributeList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHub.Model.PutResourceAttributesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MigrationTaskName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MigrationTaskName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MigrationTaskName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MigrationTaskName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-MHResourceAttribute (PutResourceAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHub.Model.PutResourceAttributesResponse, SetMHResourceAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MigrationTaskName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.MigrationTaskName = this.MigrationTaskName;
            #if MODULAR
            if (this.MigrationTaskName == null && ParameterWasBound(nameof(this.MigrationTaskName)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationTaskName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgressUpdateStream = this.ProgressUpdateStream;
            #if MODULAR
            if (this.ProgressUpdateStream == null && ParameterWasBound(nameof(this.ProgressUpdateStream)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgressUpdateStream which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceAttributeList != null)
            {
                context.ResourceAttributeList = new List<Amazon.MigrationHub.Model.ResourceAttribute>(this.ResourceAttributeList);
            }
            #if MODULAR
            if (this.ResourceAttributeList == null && ParameterWasBound(nameof(this.ResourceAttributeList)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceAttributeList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHub.Model.PutResourceAttributesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MigrationTaskName != null)
            {
                request.MigrationTaskName = cmdletContext.MigrationTaskName;
            }
            if (cmdletContext.ProgressUpdateStream != null)
            {
                request.ProgressUpdateStream = cmdletContext.ProgressUpdateStream;
            }
            if (cmdletContext.ResourceAttributeList != null)
            {
                request.ResourceAttributeList = cmdletContext.ResourceAttributeList;
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
        
        private Amazon.MigrationHub.Model.PutResourceAttributesResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.PutResourceAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "PutResourceAttributes");
            try
            {
                #if DESKTOP
                return client.PutResourceAttributes(request);
                #elif CORECLR
                return client.PutResourceAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String MigrationTaskName { get; set; }
            public System.String ProgressUpdateStream { get; set; }
            public List<Amazon.MigrationHub.Model.ResourceAttribute> ResourceAttributeList { get; set; }
            public System.Func<Amazon.MigrationHub.Model.PutResourceAttributesResponse, SetMHResourceAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
