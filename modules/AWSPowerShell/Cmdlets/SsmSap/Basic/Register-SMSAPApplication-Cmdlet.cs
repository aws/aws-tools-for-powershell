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
using Amazon.SsmSap;
using Amazon.SsmSap.Model;

namespace Amazon.PowerShell.Cmdlets.SMSAP
{
    /// <summary>
    /// Register an SAP application with AWS Systems Manager for SAP. You must meet the following
    /// requirements before registering. 
    /// 
    ///  
    /// <para>
    /// The SAP application you want to register with AWS Systems Manager for SAP is running
    /// on Amazon EC2.
    /// </para><para>
    /// AWS Systems Manager Agent must be setup on an Amazon EC2 instance along with the required
    /// IAM permissions.
    /// </para><para>
    /// Amazon EC2 instance(s) must have access to the secrets created in AWS Secrets Manager
    /// to manage SAP applications and components.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "SMSAPApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SsmSap.Model.RegisterApplicationResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager for SAP RegisterApplication API operation.", Operation = new[] {"RegisterApplication"}, SelectReturnType = typeof(Amazon.SsmSap.Model.RegisterApplicationResponse))]
    [AWSCmdletOutput("Amazon.SsmSap.Model.RegisterApplicationResponse",
        "This cmdlet returns an Amazon.SsmSap.Model.RegisterApplicationResponse object containing multiple properties."
    )]
    public partial class RegisterSMSAPApplicationCmdlet : AmazonSsmSapClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ApplicationType
        /// <summary>
        /// <para>
        /// <para>The type of the application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SsmSap.ApplicationType")]
        public Amazon.SsmSap.ApplicationType ApplicationType { get; set; }
        #endregion
        
        #region Parameter ComponentsInfo
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter for component details to which the SAP ABAP application
        /// is attached, such as Web Dispatcher.</para><para>This is an array of ApplicationComponent objects. You may input 0 to 5 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SsmSap.Model.ComponentInfo[] ComponentsInfo { get; set; }
        #endregion
        
        #region Parameter ApplicationCredentials
        /// <summary>
        /// <para>
        /// <para>The credentials of the SAP application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SsmSap.Model.ApplicationCredential[] ApplicationCredentials { get; set; }
        #endregion
        
        #region Parameter DatabaseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the SAP HANA database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseArn { get; set; }
        #endregion
        
        #region Parameter Instance
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instances on which your SAP application is running.</para>
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
        [Alias("Instances")]
        public System.String[] Instance { get; set; }
        #endregion
        
        #region Parameter SapInstanceNumber
        /// <summary>
        /// <para>
        /// <para>The SAP instance number of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SapInstanceNumber { get; set; }
        #endregion
        
        #region Parameter Sid
        /// <summary>
        /// <para>
        /// <para>The System ID of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sid { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be attached to the SAP application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SsmSap.Model.RegisterApplicationResponse).
        /// Specifying the name of a property of type Amazon.SsmSap.Model.RegisterApplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SMSAPApplication (RegisterApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SsmSap.Model.RegisterApplicationResponse, RegisterSMSAPApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplicationType = this.ApplicationType;
            #if MODULAR
            if (this.ApplicationType == null && ParameterWasBound(nameof(this.ApplicationType)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentsInfo != null)
            {
                context.ComponentsInfo = new List<Amazon.SsmSap.Model.ComponentInfo>(this.ComponentsInfo);
            }
            if (this.ApplicationCredentials != null)
            {
                context.ApplicationCredentials = new List<Amazon.SsmSap.Model.ApplicationCredential>(this.ApplicationCredentials);
            }
            context.DatabaseArn = this.DatabaseArn;
            if (this.Instance != null)
            {
                context.Instance = new List<System.String>(this.Instance);
            }
            #if MODULAR
            if (this.Instance == null && ParameterWasBound(nameof(this.Instance)))
            {
                WriteWarning("You are passing $null as a value for parameter Instance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SapInstanceNumber = this.SapInstanceNumber;
            context.Sid = this.Sid;
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
            var request = new Amazon.SsmSap.Model.RegisterApplicationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ApplicationType != null)
            {
                request.ApplicationType = cmdletContext.ApplicationType;
            }
            if (cmdletContext.ComponentsInfo != null)
            {
                request.ComponentsInfo = cmdletContext.ComponentsInfo;
            }
            if (cmdletContext.ApplicationCredentials != null)
            {
                request.Credentials = cmdletContext.ApplicationCredentials;
            }
            if (cmdletContext.DatabaseArn != null)
            {
                request.DatabaseArn = cmdletContext.DatabaseArn;
            }
            if (cmdletContext.Instance != null)
            {
                request.Instances = cmdletContext.Instance;
            }
            if (cmdletContext.SapInstanceNumber != null)
            {
                request.SapInstanceNumber = cmdletContext.SapInstanceNumber;
            }
            if (cmdletContext.Sid != null)
            {
                request.Sid = cmdletContext.Sid;
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
        
        private Amazon.SsmSap.Model.RegisterApplicationResponse CallAWSServiceOperation(IAmazonSsmSap client, Amazon.SsmSap.Model.RegisterApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager for SAP", "RegisterApplication");
            try
            {
                #if DESKTOP
                return client.RegisterApplication(request);
                #elif CORECLR
                return client.RegisterApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Amazon.SsmSap.ApplicationType ApplicationType { get; set; }
            public List<Amazon.SsmSap.Model.ComponentInfo> ComponentsInfo { get; set; }
            public List<Amazon.SsmSap.Model.ApplicationCredential> ApplicationCredentials { get; set; }
            public System.String DatabaseArn { get; set; }
            public List<System.String> Instance { get; set; }
            public System.String SapInstanceNumber { get; set; }
            public System.String Sid { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SsmSap.Model.RegisterApplicationResponse, RegisterSMSAPApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
