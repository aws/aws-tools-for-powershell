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
using Amazon.CodeCatalyst;
using Amazon.CodeCatalyst.Model;

namespace Amazon.PowerShell.Cmdlets.CCAT
{
    /// <summary>
    /// Creates a Dev Environment in Amazon CodeCatalyst, a cloud-based development environment
    /// that you can use to quickly work on the code stored in the source repositories of
    /// your project. 
    /// 
    ///  <note><para>
    /// When created in the Amazon CodeCatalyst console, by default a Dev Environment is configured
    /// to have a 2 core processor, 4GB of RAM, and 16GB of persistent storage. None of these
    /// defaults apply to a Dev Environment created programmatically.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CCATDevEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS CodeCatalyst CreateDevEnvironment API operation.", Operation = new[] {"CreateDevEnvironment"}, SelectReturnType = typeof(Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse",
        "This cmdlet returns an Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse object containing multiple properties."
    )]
    public partial class NewCCATDevEnvironmentCmdlet : AmazonCodeCatalystClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The user-defined alias for a Dev Environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter Ide
        /// <summary>
        /// <para>
        /// <para>Information about the integrated development environment (IDE) configured for a Dev
        /// Environment.</para><note><para>An IDE is required to create a Dev Environment. For Dev Environment creation, this
        /// field contains configuration information and must be provided. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ides")]
        public Amazon.CodeCatalyst.Model.IdeConfiguration[] Ide { get; set; }
        #endregion
        
        #region Parameter InactivityTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time the Dev Environment will run without any activity detected before
        /// stopping, in minutes. Only whole integers are allowed. Dev Environments consume compute
        /// minutes when running.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InactivityTimeoutMinutes")]
        public System.Int32? InactivityTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instace type to use for the Dev Environment. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeCatalyst.InstanceType")]
        public Amazon.CodeCatalyst.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in the space.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para>The source repository that contains the branch to clone into the Dev Environment.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repositories")]
        public Amazon.CodeCatalyst.Model.RepositoryInput[] Repository { get; set; }
        #endregion
        
        #region Parameter PersistentStorage_SizeInGiB
        /// <summary>
        /// <para>
        /// <para>The size of the persistent storage in gigabytes (specifically GiB).</para><note><para>Valid values for storage are based on memory sizes in 16GB increments. Valid values
        /// are 16, 32, and 64.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? PersistentStorage_SizeInGiB { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
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
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter VpcConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection that will be used to connect to Amazon VPC, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConnectionName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A user-specified idempotency token. Idempotency ensures that an API request completes
        /// only once. With an idempotent request, if the original request completes successfully,
        /// the subsequent retries return the result from the original successful request and
        /// have no additional effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            this._ExecuteWithAnonymousCredentials = true;
            this._AWSSignerType = "bearer";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCATDevEnvironment (CreateDevEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse, NewCCATDevEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            if (this.Ide != null)
            {
                context.Ide = new List<Amazon.CodeCatalyst.Model.IdeConfiguration>(this.Ide);
            }
            context.InactivityTimeoutMinute = this.InactivityTimeoutMinute;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersistentStorage_SizeInGiB = this.PersistentStorage_SizeInGiB;
            #if MODULAR
            if (this.PersistentStorage_SizeInGiB == null && ParameterWasBound(nameof(this.PersistentStorage_SizeInGiB)))
            {
                WriteWarning("You are passing $null as a value for parameter PersistentStorage_SizeInGiB which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Repository != null)
            {
                context.Repository = new List<Amazon.CodeCatalyst.Model.RepositoryInput>(this.Repository);
            }
            context.SpaceName = this.SpaceName;
            #if MODULAR
            if (this.SpaceName == null && ParameterWasBound(nameof(this.SpaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcConnectionName = this.VpcConnectionName;
            
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
            var request = new Amazon.CodeCatalyst.Model.CreateDevEnvironmentRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Ide != null)
            {
                request.Ides = cmdletContext.Ide;
            }
            if (cmdletContext.InactivityTimeoutMinute != null)
            {
                request.InactivityTimeoutMinutes = cmdletContext.InactivityTimeoutMinute.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            
             // populate PersistentStorage
            var requestPersistentStorageIsNull = true;
            request.PersistentStorage = new Amazon.CodeCatalyst.Model.PersistentStorageConfiguration();
            System.Int32? requestPersistentStorage_persistentStorage_SizeInGiB = null;
            if (cmdletContext.PersistentStorage_SizeInGiB != null)
            {
                requestPersistentStorage_persistentStorage_SizeInGiB = cmdletContext.PersistentStorage_SizeInGiB.Value;
            }
            if (requestPersistentStorage_persistentStorage_SizeInGiB != null)
            {
                request.PersistentStorage.SizeInGiB = requestPersistentStorage_persistentStorage_SizeInGiB.Value;
                requestPersistentStorageIsNull = false;
            }
             // determine if request.PersistentStorage should be set to null
            if (requestPersistentStorageIsNull)
            {
                request.PersistentStorage = null;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repositories = cmdletContext.Repository;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
            }
            if (cmdletContext.VpcConnectionName != null)
            {
                request.VpcConnectionName = cmdletContext.VpcConnectionName;
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
        
        private Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse CallAWSServiceOperation(IAmazonCodeCatalyst client, Amazon.CodeCatalyst.Model.CreateDevEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCatalyst", "CreateDevEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateDevEnvironment(request);
                #elif CORECLR
                return client.CreateDevEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.CodeCatalyst.Model.IdeConfiguration> Ide { get; set; }
            public System.Int32? InactivityTimeoutMinute { get; set; }
            public Amazon.CodeCatalyst.InstanceType InstanceType { get; set; }
            public System.Int32? PersistentStorage_SizeInGiB { get; set; }
            public System.String ProjectName { get; set; }
            public List<Amazon.CodeCatalyst.Model.RepositoryInput> Repository { get; set; }
            public System.String SpaceName { get; set; }
            public System.String VpcConnectionName { get; set; }
            public System.Func<Amazon.CodeCatalyst.Model.CreateDevEnvironmentResponse, NewCCATDevEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
