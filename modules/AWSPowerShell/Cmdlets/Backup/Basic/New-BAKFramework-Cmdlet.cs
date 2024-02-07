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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Creates a framework with one or more controls. A framework is a collection of controls
    /// that you can use to evaluate your backup practices. By using pre-built customizable
    /// controls to define your policies, you can evaluate whether your backup practices comply
    /// with your policies and which resources are not yet in compliance.
    /// </summary>
    [Cmdlet("New", "BAKFramework", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateFrameworkResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateFramework API operation.", Operation = new[] {"CreateFramework"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateFrameworkResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateFrameworkResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateFrameworkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBAKFrameworkCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FrameworkControl
        /// <summary>
        /// <para>
        /// <para>A list of the controls that make up the framework. Each control in the list has a
        /// name, input parameters, and scope.</para>
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
        [Alias("FrameworkControls")]
        public Amazon.Backup.Model.FrameworkControl[] FrameworkControl { get; set; }
        #endregion
        
        #region Parameter FrameworkDescription
        /// <summary>
        /// <para>
        /// <para>An optional description of the framework with a maximum of 1,024 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FrameworkDescription { get; set; }
        #endregion
        
        #region Parameter FrameworkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the framework. The name must be between 1 and 256 characters, starting
        /// with a letter, and consisting of letters (a-z, A-Z), numbers (0-9), and underscores
        /// (_).</para>
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
        public System.String FrameworkName { get; set; }
        #endregion
        
        #region Parameter FrameworkTag
        /// <summary>
        /// <para>
        /// <para>Metadata that you can assign to help organize the frameworks that you create. Each
        /// tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FrameworkTags")]
        public System.Collections.Hashtable FrameworkTag { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A customer-chosen string that you can use to distinguish between otherwise identical
        /// calls to <c>CreateFrameworkInput</c>. Retrying a successful request with the same
        /// idempotency token results in a success message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateFrameworkResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateFrameworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FrameworkName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FrameworkName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FrameworkName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FrameworkName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKFramework (CreateFramework)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateFrameworkResponse, NewBAKFrameworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FrameworkName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FrameworkControl != null)
            {
                context.FrameworkControl = new List<Amazon.Backup.Model.FrameworkControl>(this.FrameworkControl);
            }
            #if MODULAR
            if (this.FrameworkControl == null && ParameterWasBound(nameof(this.FrameworkControl)))
            {
                WriteWarning("You are passing $null as a value for parameter FrameworkControl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FrameworkDescription = this.FrameworkDescription;
            context.FrameworkName = this.FrameworkName;
            #if MODULAR
            if (this.FrameworkName == null && ParameterWasBound(nameof(this.FrameworkName)))
            {
                WriteWarning("You are passing $null as a value for parameter FrameworkName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FrameworkTag != null)
            {
                context.FrameworkTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FrameworkTag.Keys)
                {
                    context.FrameworkTag.Add((String)hashKey, (System.String)(this.FrameworkTag[hashKey]));
                }
            }
            context.IdempotencyToken = this.IdempotencyToken;
            
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
            var request = new Amazon.Backup.Model.CreateFrameworkRequest();
            
            if (cmdletContext.FrameworkControl != null)
            {
                request.FrameworkControls = cmdletContext.FrameworkControl;
            }
            if (cmdletContext.FrameworkDescription != null)
            {
                request.FrameworkDescription = cmdletContext.FrameworkDescription;
            }
            if (cmdletContext.FrameworkName != null)
            {
                request.FrameworkName = cmdletContext.FrameworkName;
            }
            if (cmdletContext.FrameworkTag != null)
            {
                request.FrameworkTags = cmdletContext.FrameworkTag;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
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
        
        private Amazon.Backup.Model.CreateFrameworkResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateFrameworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateFramework");
            try
            {
                #if DESKTOP
                return client.CreateFramework(request);
                #elif CORECLR
                return client.CreateFrameworkAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Backup.Model.FrameworkControl> FrameworkControl { get; set; }
            public System.String FrameworkDescription { get; set; }
            public System.String FrameworkName { get; set; }
            public Dictionary<System.String, System.String> FrameworkTag { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Func<Amazon.Backup.Model.CreateFrameworkResponse, NewBAKFrameworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
