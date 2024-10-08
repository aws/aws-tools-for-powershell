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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Creates a serverless cache.
    /// </summary>
    [Cmdlet("New", "ECServerlessCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCache")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateServerlessCache API operation.", Operation = new[] {"CreateServerlessCache"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateServerlessCacheResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCache or Amazon.ElastiCache.Model.CreateServerlessCacheResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ServerlessCache object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateServerlessCacheResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECServerlessCacheCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DailySnapshotTime
        /// <summary>
        /// <para>
        /// <para>The daily time that snapshots will be created from the new serverless cache. By default
        /// this number is populated with 0, i.e. no snapshots will be created on an automatic
        /// daily basis. Available for Valkey, Redis OSS and Serverless Memcached only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DailySnapshotTime { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>User-provided description for the serverless cache. The default is NULL, i.e. if no
        /// description is provided then an empty string will be returned. The maximum length
        /// is 255 characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the cache engine to be used for creating the serverless cache.</para>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>ARN of the customer managed key for encrypting the data at rest. If no KMS key is
        /// provided, a default service key is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MajorEngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the cache engine that will be used to create the serverless cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MajorEngineVersion { get; set; }
        #endregion
        
        #region Parameter DataStorage_Maximum
        /// <summary>
        /// <para>
        /// <para>The upper limit for data storage the cache is set to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheUsageLimits_DataStorage_Maximum")]
        public System.Int32? DataStorage_Maximum { get; set; }
        #endregion
        
        #region Parameter ECPUPerSecond_Maximum
        /// <summary>
        /// <para>
        /// <para>The configuration for the maximum number of ECPUs the cache can consume per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheUsageLimits_ECPUPerSecond_Maximum")]
        public System.Int32? ECPUPerSecond_Maximum { get; set; }
        #endregion
        
        #region Parameter DataStorage_Minimum
        /// <summary>
        /// <para>
        /// <para>The lower limit for data storage the cache is set to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheUsageLimits_DataStorage_Minimum")]
        public System.Int32? DataStorage_Minimum { get; set; }
        #endregion
        
        #region Parameter ECPUPerSecond_Minimum
        /// <summary>
        /// <para>
        /// <para>The configuration for the minimum number of ECPUs the cache should be able consume
        /// per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheUsageLimits_ECPUPerSecond_Minimum")]
        public System.Int32? ECPUPerSecond_Minimum { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of the one or more VPC security groups to be associated with the serverless
        /// cache. The security group will authorize traffic access for the VPC end-point (private-link).
        /// If no other information is given this will be the VPC’s Default Security Group that
        /// is associated with the cluster VPC end-point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServerlessCacheName
        /// <summary>
        /// <para>
        /// <para>User-provided identifier for the serverless cache. This parameter is stored as a lowercase
        /// string.</para>
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
        public System.String ServerlessCacheName { get; set; }
        #endregion
        
        #region Parameter SnapshotArnsToRestore
        /// <summary>
        /// <para>
        /// <para>The ARN(s) of the snapshot that the new serverless cache will be created from. Available
        /// for Valkey, Redis OSS and Serverless Memcached only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SnapshotArnsToRestore { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of snapshots that will be retained for the serverless cache that is being
        /// created. As new snapshots beyond this limit are added, the oldest snapshots will be
        /// deleted on a rolling basis. Available for Valkey, Redis OSS and Serverless Memcached
        /// only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of the identifiers of the subnets where the VPC endpoint for the serverless
        /// cache will be deployed. All the subnetIds must belong to the same VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags (key, value) pairs to be added to the serverless cache resource.
        /// Default is NULL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DataStorage_Unit
        /// <summary>
        /// <para>
        /// <para>The unit that the storage is measured in, in GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheUsageLimits_DataStorage_Unit")]
        [AWSConstantClassSource("Amazon.ElastiCache.DataStorageUnit")]
        public Amazon.ElastiCache.DataStorageUnit DataStorage_Unit { get; set; }
        #endregion
        
        #region Parameter UserGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the UserGroup to be associated with the serverless cache. Available
        /// for Valkey and Redis OSS only. Default is NULL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCache'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateServerlessCacheResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateServerlessCacheResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCache";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerlessCacheName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerlessCacheName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerlessCacheName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerlessCacheName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECServerlessCache (CreateServerlessCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateServerlessCacheResponse, NewECServerlessCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerlessCacheName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataStorage_Maximum = this.DataStorage_Maximum;
            context.DataStorage_Minimum = this.DataStorage_Minimum;
            context.DataStorage_Unit = this.DataStorage_Unit;
            context.ECPUPerSecond_Maximum = this.ECPUPerSecond_Maximum;
            context.ECPUPerSecond_Minimum = this.ECPUPerSecond_Minimum;
            context.DailySnapshotTime = this.DailySnapshotTime;
            context.Description = this.Description;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.MajorEngineVersion = this.MajorEngineVersion;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.ServerlessCacheName = this.ServerlessCacheName;
            #if MODULAR
            if (this.ServerlessCacheName == null && ParameterWasBound(nameof(this.ServerlessCacheName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerlessCacheName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SnapshotArnsToRestore != null)
            {
                context.SnapshotArnsToRestore = new List<System.String>(this.SnapshotArnsToRestore);
            }
            context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
            }
            context.UserGroupId = this.UserGroupId;
            
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
            var request = new Amazon.ElastiCache.Model.CreateServerlessCacheRequest();
            
            
             // populate CacheUsageLimits
            var requestCacheUsageLimitsIsNull = true;
            request.CacheUsageLimits = new Amazon.ElastiCache.Model.CacheUsageLimits();
            Amazon.ElastiCache.Model.ECPUPerSecond requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond = null;
            
             // populate ECPUPerSecond
            var requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecondIsNull = true;
            requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond = new Amazon.ElastiCache.Model.ECPUPerSecond();
            System.Int32? requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Maximum = null;
            if (cmdletContext.ECPUPerSecond_Maximum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Maximum = cmdletContext.ECPUPerSecond_Maximum.Value;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Maximum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond.Maximum = requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Maximum.Value;
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecondIsNull = false;
            }
            System.Int32? requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Minimum = null;
            if (cmdletContext.ECPUPerSecond_Minimum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Minimum = cmdletContext.ECPUPerSecond_Minimum.Value;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Minimum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond.Minimum = requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond_eCPUPerSecond_Minimum.Value;
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecondIsNull = false;
            }
             // determine if requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond should be set to null
            if (requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecondIsNull)
            {
                requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond = null;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond != null)
            {
                request.CacheUsageLimits.ECPUPerSecond = requestCacheUsageLimits_cacheUsageLimits_ECPUPerSecond;
                requestCacheUsageLimitsIsNull = false;
            }
            Amazon.ElastiCache.Model.DataStorage requestCacheUsageLimits_cacheUsageLimits_DataStorage = null;
            
             // populate DataStorage
            var requestCacheUsageLimits_cacheUsageLimits_DataStorageIsNull = true;
            requestCacheUsageLimits_cacheUsageLimits_DataStorage = new Amazon.ElastiCache.Model.DataStorage();
            System.Int32? requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Maximum = null;
            if (cmdletContext.DataStorage_Maximum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Maximum = cmdletContext.DataStorage_Maximum.Value;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Maximum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage.Maximum = requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Maximum.Value;
                requestCacheUsageLimits_cacheUsageLimits_DataStorageIsNull = false;
            }
            System.Int32? requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Minimum = null;
            if (cmdletContext.DataStorage_Minimum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Minimum = cmdletContext.DataStorage_Minimum.Value;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Minimum != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage.Minimum = requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Minimum.Value;
                requestCacheUsageLimits_cacheUsageLimits_DataStorageIsNull = false;
            }
            Amazon.ElastiCache.DataStorageUnit requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Unit = null;
            if (cmdletContext.DataStorage_Unit != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Unit = cmdletContext.DataStorage_Unit;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Unit != null)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage.Unit = requestCacheUsageLimits_cacheUsageLimits_DataStorage_dataStorage_Unit;
                requestCacheUsageLimits_cacheUsageLimits_DataStorageIsNull = false;
            }
             // determine if requestCacheUsageLimits_cacheUsageLimits_DataStorage should be set to null
            if (requestCacheUsageLimits_cacheUsageLimits_DataStorageIsNull)
            {
                requestCacheUsageLimits_cacheUsageLimits_DataStorage = null;
            }
            if (requestCacheUsageLimits_cacheUsageLimits_DataStorage != null)
            {
                request.CacheUsageLimits.DataStorage = requestCacheUsageLimits_cacheUsageLimits_DataStorage;
                requestCacheUsageLimitsIsNull = false;
            }
             // determine if request.CacheUsageLimits should be set to null
            if (requestCacheUsageLimitsIsNull)
            {
                request.CacheUsageLimits = null;
            }
            if (cmdletContext.DailySnapshotTime != null)
            {
                request.DailySnapshotTime = cmdletContext.DailySnapshotTime;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MajorEngineVersion != null)
            {
                request.MajorEngineVersion = cmdletContext.MajorEngineVersion;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.ServerlessCacheName != null)
            {
                request.ServerlessCacheName = cmdletContext.ServerlessCacheName;
            }
            if (cmdletContext.SnapshotArnsToRestore != null)
            {
                request.SnapshotArnsToRestore = cmdletContext.SnapshotArnsToRestore;
            }
            if (cmdletContext.SnapshotRetentionLimit != null)
            {
                request.SnapshotRetentionLimit = cmdletContext.SnapshotRetentionLimit.Value;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserGroupId != null)
            {
                request.UserGroupId = cmdletContext.UserGroupId;
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
        
        private Amazon.ElastiCache.Model.CreateServerlessCacheResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateServerlessCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateServerlessCache");
            try
            {
                #if DESKTOP
                return client.CreateServerlessCache(request);
                #elif CORECLR
                return client.CreateServerlessCacheAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DataStorage_Maximum { get; set; }
            public System.Int32? DataStorage_Minimum { get; set; }
            public Amazon.ElastiCache.DataStorageUnit DataStorage_Unit { get; set; }
            public System.Int32? ECPUPerSecond_Maximum { get; set; }
            public System.Int32? ECPUPerSecond_Minimum { get; set; }
            public System.String DailySnapshotTime { get; set; }
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MajorEngineVersion { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String ServerlessCacheName { get; set; }
            public List<System.String> SnapshotArnsToRestore { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.String UserGroupId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateServerlessCacheResponse, NewECServerlessCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCache;
        }
        
    }
}
