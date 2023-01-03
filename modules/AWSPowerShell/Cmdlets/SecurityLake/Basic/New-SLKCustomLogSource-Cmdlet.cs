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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Adds a third-party custom source in Amazon Security Lake, from the Amazon Web Services
    /// Region where you want to create a custom source. Security Lake can collect logs and
    /// events from third-party custom sources. After creating the appropriate IAM role to
    /// invoke Glue crawler, use this API to add a custom source name in Security Lake. This
    /// operation creates a partition in the Amazon S3 bucket for Security Lake as the target
    /// location for log files from the custom source in addition to an associated Glue table
    /// and an Glue crawler.
    /// </summary>
    [Cmdlet("New", "SLKCustomLogSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.CreateCustomLogSourceResponse")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateCustomLogSource API operation.", Operation = new[] {"CreateCustomLogSource"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateCustomLogSourceResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.CreateCustomLogSourceResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.CreateCustomLogSourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSLKCustomLogSourceCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        #region Parameter CustomSourceName
        /// <summary>
        /// <para>
        /// <para>The name for a third-party custom source. This must be a Regionally unique value.</para>
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
        public System.String CustomSourceName { get; set; }
        #endregion
        
        #region Parameter EventClass
        /// <summary>
        /// <para>
        /// <para>The Open Cybersecurity Schema Framework (OCSF) event class which describes the type
        /// of data that the custom source will send to Security Lake.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityLake.OcsfEventClass")]
        public Amazon.SecurityLake.OcsfEventClass EventClass { get; set; }
        #endregion
        
        #region Parameter GlueInvocationRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role to
        /// be used by the Glue crawler. The recommended IAM policies are:</para><ul><li><para>The managed policy <code>AWSGlueServiceRole</code></para></li><li><para>A custom policy granting access to your Amazon S3 Data Lake</para></li></ul>
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
        public System.String GlueInvocationRoleArn { get; set; }
        #endregion
        
        #region Parameter LogProviderAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the custom source that will write logs and events
        /// into the Amazon S3 Data Lake.</para>
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
        public System.String LogProviderAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateCustomLogSourceResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateCustomLogSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventClass parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventClass' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventClass' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomSourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKCustomLogSource (CreateCustomLogSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateCustomLogSourceResponse, NewSLKCustomLogSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventClass;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomSourceName = this.CustomSourceName;
            #if MODULAR
            if (this.CustomSourceName == null && ParameterWasBound(nameof(this.CustomSourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomSourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventClass = this.EventClass;
            #if MODULAR
            if (this.EventClass == null && ParameterWasBound(nameof(this.EventClass)))
            {
                WriteWarning("You are passing $null as a value for parameter EventClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlueInvocationRoleArn = this.GlueInvocationRoleArn;
            #if MODULAR
            if (this.GlueInvocationRoleArn == null && ParameterWasBound(nameof(this.GlueInvocationRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GlueInvocationRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogProviderAccountId = this.LogProviderAccountId;
            #if MODULAR
            if (this.LogProviderAccountId == null && ParameterWasBound(nameof(this.LogProviderAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter LogProviderAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityLake.Model.CreateCustomLogSourceRequest();
            
            if (cmdletContext.CustomSourceName != null)
            {
                request.CustomSourceName = cmdletContext.CustomSourceName;
            }
            if (cmdletContext.EventClass != null)
            {
                request.EventClass = cmdletContext.EventClass;
            }
            if (cmdletContext.GlueInvocationRoleArn != null)
            {
                request.GlueInvocationRoleArn = cmdletContext.GlueInvocationRoleArn;
            }
            if (cmdletContext.LogProviderAccountId != null)
            {
                request.LogProviderAccountId = cmdletContext.LogProviderAccountId;
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
        
        private Amazon.SecurityLake.Model.CreateCustomLogSourceResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateCustomLogSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateCustomLogSource");
            try
            {
                #if DESKTOP
                return client.CreateCustomLogSource(request);
                #elif CORECLR
                return client.CreateCustomLogSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomSourceName { get; set; }
            public Amazon.SecurityLake.OcsfEventClass EventClass { get; set; }
            public System.String GlueInvocationRoleArn { get; set; }
            public System.String LogProviderAccountId { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateCustomLogSourceResponse, NewSLKCustomLogSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
